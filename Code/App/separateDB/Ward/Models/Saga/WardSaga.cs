using Messages;
using Messages.Ward;
using NServiceBus;
using NServiceBus.Saga;
using RepositoryClasses.Models;
using System;
using System.Linq;
using Ward.Hubs.Services;
using Ward.Models;
using Ward.ViewModels;
using WardBusinessLogic.Services;

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
        private readonly IExaminationsService _examinationsService;

        public WardSaga(IShowToUIHubService showToUIHubService,
            IPatientsService patientService,
            IPatientsDieseasesService patientsDieseasesService,
            IExaminationsService examinationsService)
        {
            _patientsService = patientService;
            _showToUIHubService = showToUIHubService;
            _patientsDieseasesService = patientsDieseasesService;
            _examinationsService = examinationsService;
        }

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<WardSagaData> mapper)
        {
            mapper.ConfigureMapping<IWardAddingExamination>(s => s.PatientDieseaseId)
                    .ToSaga(m => m.PatientDieseaseId);
            mapper.ConfigureMapping<IWardAcceptance>(s => s.Diesease.PatientDieseaseId) 
                    .ToSaga(m => m.PatientDieseaseId);
            mapper.ConfigureMapping<ILabWardResults>(s => s.Examination.ExtPatientDieseaseId)
                   .ToSaga(m => m.PatientDieseaseId);
            mapper.ConfigureMapping<IUSGWardResults>(s => s.Examination.ExtPatientDieseaseId)
                   .ToSaga(m => m.PatientDieseaseId);
            mapper.ConfigureMapping<IRTGWardResults>(s => s.Examination.ExtPatientDieseaseId)
                   .ToSaga(m => m.PatientDieseaseId);
            mapper.ConfigureMapping<IWardAddingExamination>(s => s.PatientDieseaseId)
                   .ToSaga(m => m.PatientDieseaseId);
        }

        public void Handle(IWardAcceptance message)
        {
            base.Data.PatientDieseaseId = message.Diesease.PatientDieseaseId;

            int patientId = -1;
            if (!_patientsService.AddIfNotExist(message.Patient, ref patientId).IsSuccess)
            {
                return;
            }
            var patientInfo = new PatientsModel
            {
                Id = patientId,
                Name = message.Patient.Name,
                Age = message.Patient.Age
            };

            int patientDieseaseId = -1;
            if(!_patientsDieseasesService.Add(message.Diesease, patientId, ref patientDieseaseId).IsSuccess)
            {
                return;
            }

            var currentDiesease = new WardPatientCurrentDieseaseViewModel
            {
                DieseaseDescription = message.Diesease.Description,
                PatientDieseaseId = message.Diesease.PatientDieseaseId
            };

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

            var examinationMessage = new ExaminationMessage
                {
                    Comment = message.Comment,
                    When = DateTime.Now,
                    ExtPatientDieseaseId = message.PatientDieseaseId
                };
            int examinationId = -1;
            var addExaminationCommand = _examinationsService.Add(
                examinationMessage,
                message.Type,
                Messages.Models.LogTypeEnum.LogType.Request,
                ref examinationId
                );

           if (addExaminationCommand.IsSuccess)
           {
               switch (message.Type)
               {
                   case ExaminationTypeEnum.ExaminationType.BLOOD:
                       Bus.Send(new WardBloodExaminationRequest
                       {
                           Examination = examinationMessage
                       });
                       break;
                   case ExaminationTypeEnum.ExaminationType.RTG:
                       Bus.Send(new WardRTGExaminationRequest
                       {
                           Examination = examinationMessage
                       });
                       break;
                   case ExaminationTypeEnum.ExaminationType.USG:
                       Bus.Send(new WardUSGExaminationRequest
                       {
                           Examination = examinationMessage
                       });
                       break;
               }
           }
        }

        public void Handle(IRTGWardResults message)
        {
            AddLogToUIAndTryFinish(message.Examination, ExaminationTypeEnum.ExaminationType.RTG);
        }

        public void Handle(IUSGWardResults message)
        {
            AddLogToUIAndTryFinish(message.Examination, ExaminationTypeEnum.ExaminationType.USG);
        }

        public void Handle(ILabWardResults message)
        {
            AddLogToUIAndTryFinish(message.Examination, ExaminationTypeEnum.ExaminationType.LAB);
        }

        private void AddLogToUIAndTryFinish(ExaminationMessage examinationMessage, ExaminationTypeEnum.ExaminationType examinationType)
        {
            base.Data.PatientDieseaseId = examinationMessage.ExtPatientDieseaseId;
      
            int examinationId = -1;
            var addExaminationCommand = _examinationsService.Add(
                examinationMessage,
                examinationType,
                Messages.Models.LogTypeEnum.LogType.Response,
                ref examinationId
                );

            if (addExaminationCommand.IsSuccess)
            {
                var log = new PatientLogViewModel
                {
                    Comment = examinationMessage.Comment,
                    PatientDieseaseId = examinationMessage.ExtPatientDieseaseId,
                    ExaminationType = examinationType,
                    LogType = Messages.Models.LogTypeEnum.LogType.Response,
                    When = examinationMessage.When
                };
                _showToUIHubService.ShowPatientLog(log);

                if (log.ExaminationType != ExaminationTypeEnum.ExaminationType.LAB)
                    ConcludeExaminationAndTryFinish(log.ExaminationType);
                else
                    ConcludeExaminationAndTryFinish(ExaminationTypeEnum.ExaminationType.BLOOD);
            }
        }

        private void CheckIfTreatmentComplete()
        {
            if (!Data.Examinations.Where(x => !x.IsReceived).Any())
            {
                var patientDieseaseId = _patientsDieseasesService.GetByExtPatientDieseaseId(Data.PatientDieseaseId).Id;

                var examinations = _examinationsService.GetExaminationsByPatientDieseaseId(patientDieseaseId)
                    .Select(x => new PatientExaminationMessage
                    {
                        Comment = x.Comment,
                        ExaminationType = x.ExaminationType,
                        LogType = x.LogType,
                        PatientDieseaseId = Data.PatientDieseaseId,
                        When = x.When
                    }).ToList();

                Bus.Send(new Results_PatientRecive
                {
                    PatientDieseaseId = Data.PatientDieseaseId,
                    Examinations = examinations
                });
                MarkAsComplete();
            }
        }

        private void ConcludeExamination(ExaminationTypeEnum.ExaminationType type)
        {
            var examination = Data.Examinations.Where(x => x.Type == type && !x.IsReceived).FirstOrDefault();
            if (examination != null)
            {
                examination.IsReceived = true;
            }
        }

        private void ConcludeExaminationAndTryFinish(ExaminationTypeEnum.ExaminationType type)
        {
            ConcludeExamination(type);
            CheckIfTreatmentComplete();

        }
    }
}