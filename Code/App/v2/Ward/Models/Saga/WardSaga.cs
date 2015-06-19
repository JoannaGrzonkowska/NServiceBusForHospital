using BusinessLogic.Services;
using Messages;
using NServiceBus;
using NServiceBus.Saga;
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
        private readonly IShowToUIHubService _showToUIHubService;

        public WardSaga(IShowToUIHubService showToUIHubService,
            IPatientsService patientService)
        {
            _patientsService = patientService;
            _showToUIHubService = showToUIHubService;
        }

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<WardSagaData> mapper)
        {
            mapper.ConfigureMapping<IWardAcceptance>(s => s.PatientID)
                    .ToSaga(m => m.PatientId);
            mapper.ConfigureMapping<ILabWardResults>(s => s.PatientID)
                   .ToSaga(m => m.PatientId);
            mapper.ConfigureMapping<IUSGWardResults>(s => s.PatientID)
                   .ToSaga(m => m.PatientId);
            mapper.ConfigureMapping<IRTGWardResults>(s => s.PatientID)
                   .ToSaga(m => m.PatientId);
            mapper.ConfigureMapping<IWardAddingExamination>(s => s.PatientID)
                   .ToSaga(m => m.PatientId);
        }

        public void Handle(IWardAcceptance message)
        {
            base.Data.PatientId = message.PatientID;

            var patientInfo = _patientsService.GetById(message.PatientID);
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
            Data.Examinations.Add(new Examination(message.Type));

            switch(message.Type)
            {
                case ExaminationType.BLOOD:
                    Bus.Send(new WardBloodExaminationRequest
                    {
                        PatientID = message.PatientID,
                        Comment = message.Comment
                    });
                   break;
                case ExaminationType.RTG:
                   Bus.Send(new WardRTGExaminationRequest
                   {
                       PatientID = message.PatientID,
                       Comment = message.Comment
                   });
                   break;
                case ExaminationType.USG:
                   Bus.Send(new WardUSGExaminationRequest
                   {
                       PatientID = message.PatientID,
                       Comment = message.Comment
                   });
                   break;
            }

        }

        public void Handle(IRTGWardResults message)
        {
            base.Data.PatientId = message.PatientID;
            //_showToUIHubService.ShowRTGWardResults(message);

            ConcludeExaminationAndTryFinish(ExaminationType.RTG);
        }

        public void Handle(IUSGWardResults message)
        {
            base.Data.PatientId = message.PatientID;
            //_showToUIHubService.ShowUSGWardResults(message);

            ConcludeExaminationAndTryFinish(ExaminationType.USG);
        }

        public void Handle(ILabWardResults message)
        {
            base.Data.PatientId = message.PatientID;            
            
            var log = new PatientLogViewModel
            {
                Comment = message.Comment,
                PatientId = message.PatientID,
                ExaminationName = "Lab"
            };

            _showToUIHubService.ShowPatientLog(log);
            ConcludeExaminationAndTryFinish(ExaminationType.BLOOD);

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

        private void ConcludeExamination(ExaminationType type)
        {
            var examination = Data.Examinations.Where(x => x.Type == type && !x.IsReceived ).First();
            examination.IsReceived = true;
        }

        private void ConcludeExaminationAndTryFinish(ExaminationType type)
        {
            ConcludeExamination(type);
            CheckIfTreatmentComplete();

        }
    }
}