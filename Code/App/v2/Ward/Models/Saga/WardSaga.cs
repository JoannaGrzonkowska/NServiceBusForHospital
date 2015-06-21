using BusinessLogic.Services;
using Messages;
using NServiceBus;
using NServiceBus.Saga;
using System;
using System.Linq;
using Ward.Hubs.Services;
using Ward.Models;
using Ward.ViewModels;

namespace Ward
{
    public class WardSaga : Saga<WardSagaData>,
        IAmStartedByMessages<IWardAcceptance>,
        IHandleMessages<ILabWardResults>,
        IHandleMessages<IRTGWardResults>,
        IHandleMessages<IUSGWardResults>,
        IHandleMessages<IWardAddingExamination>
    {
        private readonly IPatientsService _patientsService;
        private readonly IPatientsDieseasesService _patientsDieseasesService;
        private readonly IShowToUIHubService _showToUIHubService;

        public WardSaga(IShowToUIHubService showToUIHubService,
            IPatientsService patientService,
            IPatientsDieseasesService patientsDieseasesService)
        {
            _patientsService = patientService;
            _showToUIHubService = showToUIHubService;
            _patientsDieseasesService = patientsDieseasesService;
        }

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<WardSagaData> mapper)
        {
            mapper.ConfigureMapping<IWardAcceptance>(s => s.PatientID) //TODO : PatientDieseaseId
                    .ToSaga(m => m.PatientId);
            mapper.ConfigureMapping<ILabWardResults>(s => s.PatientID)//TODO : PatientDieseaseId
                   .ToSaga(m => m.PatientId);
            mapper.ConfigureMapping<IUSGWardResults>(s => s.PatientID)//TODO : PatientDieseaseId
                   .ToSaga(m => m.PatientId);
            mapper.ConfigureMapping<IRTGWardResults>(s => s.PatientID)//TODO : PatientDieseaseId
                   .ToSaga(m => m.PatientId);
            mapper.ConfigureMapping<IWardAddingExamination>(s => s.PatientID)//TODO : PatientDieseaseId
                   .ToSaga(m => m.PatientId);
        }

        public void Handle(IWardAcceptance message)
        {
            var patientInfo = _patientsDieseasesService.GetPatientById(message.PatientDieseaseId);
            base.Data.PatientId = patientInfo.Id;

            var currentDiesease = new WardPatientCurrentDieseaseViewModel { DieseaseDescription = message.Description };
            var patientDeclaration = new WardPatientDeclarationViewModel
            {
                PatientInfo = patientInfo,
                CurrentDiesease = currentDiesease
            };

            
            _showToUIHubService.ShowWardAcceptance(patientDeclaration);
        }

        public void Handle(IWardAddingExamination message)
        {
            message.When = DateTime.Now;
            Data.Examinations.Add(new Examination(message.Type));

            switch(message.Type)
            {
                case ExaminationTypeEnum.ExaminationType.BLOOD:
                    Bus.Send(new WardBloodExaminationRequest
                    {
                        PatientID = message.PatientID,
                        Comment = message.Comment //todo passing when
                    });
                   break;
                case ExaminationTypeEnum.ExaminationType.RTG:
                   Bus.Send(new WardRTGExaminationRequest
                   {
                       PatientID = message.PatientID,
                       Comment = message.Comment
                   });
                   break;
                case ExaminationTypeEnum.ExaminationType.USG:
                   Bus.Send(new WardUSGExaminationRequest
                   {
                       PatientID = message.PatientID,
                       Comment = message.Comment
                   });
                   break;
            }

        }

        private void AddLogToUIAndTryFinish(PatientLogViewModel log)
        {
            log.LogType = Messages.Models.LogTypeEnum.LogType.Response;
            _showToUIHubService.ShowPatientLog(log);
            ConcludeExaminationAndTryFinish(log.ExaminationType);
        }

        public void Handle(IRTGWardResults message)
        {
            base.Data.PatientId = message.PatientID;

            AddLogToUIAndTryFinish(new PatientLogViewModel
            {
                Comment = message.Comment,
                PatientId = message.PatientID,
                ExaminationType = ExaminationTypeEnum.ExaminationType.RTG
            });
        }

        public void Handle(IUSGWardResults message)
        {
            base.Data.PatientId = message.PatientID;
            AddLogToUIAndTryFinish(new PatientLogViewModel
           {
               Comment = message.Comment,
               PatientId = message.PatientID,
               ExaminationType = ExaminationTypeEnum.ExaminationType.USG
           });
        }

        public void Handle(ILabWardResults message)
        {
            base.Data.PatientId = message.PatientID;

            AddLogToUIAndTryFinish(new PatientLogViewModel
            {
                Comment = message.Comment,
                PatientId = message.PatientID,
                ExaminationType = ExaminationTypeEnum.ExaminationType.LAB
            });
        }


        private void CheckIfTreatmentComplete()
        {
            if (!Data.Examinations.Where(x => !x.IsReceived).Any())
            {
                ReplyToOriginator(new Results_PatientRecive
                {
                    Comment = "Treatment Completed YOLO",
                    PatientId = Data.PatientId
                });
                MarkAsComplete();
            }
        }

        private void ConcludeExamination(ExaminationTypeEnum.ExaminationType type)
        {
            var examination = Data.Examinations.Where(x => x.Type == type && !x.IsReceived ).First();
            examination.IsReceived = true;
        }

        private void ConcludeExaminationAndTryFinish(ExaminationTypeEnum.ExaminationType type)
        {
            ConcludeExamination(type);
            CheckIfTreatmentComplete();

        }
    }
}