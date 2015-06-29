using BusinessLogic.CommandHandlers;
using BusinessLogic.Services;
using Messages;
using Messages.Ward;
using Microsoft.AspNet.SignalR;
using NServiceBus;
using Patient.Hubs.Services;
using RepositoryClasses.Models;
using System.Collections;
using System.Collections.Generic;

namespace Patient.Hubs
{
    public class Results_PatientReciveHandler : IHandleMessages<IResults_PatientRecive>
    {
        private readonly IExaminationsService _examinationsService;
        private readonly IShowToUIHubService _showToUIHubService;
        private readonly IPatientsDieseasesService _patientsDieseasesService;
        private readonly IAddExaminationToPatientCommandHandler _addExaminationToPatientCommandHandler;
        
        public Results_PatientReciveHandler(IExaminationsService examinationsService, 
            IShowToUIHubService showToUIHubService,
            IPatientsDieseasesService patientsDieseasesService,
            IAddExaminationToPatientCommandHandler addExaminationToPatientCommandHandler)
        {
            _examinationsService = examinationsService;
            _showToUIHubService = showToUIHubService;
            _patientsDieseasesService = patientsDieseasesService;
            _addExaminationToPatientCommandHandler = addExaminationToPatientCommandHandler;
        }

        public void Handle(IResults_PatientRecive message)
        {
            IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<PatientHub>();
            List<ExaminationsModel> examinations = new List<ExaminationsModel>();
            message.Examinations.ForEach(x =>
            {
                var examinationModel = new ExaminationsModel
                {
                    Comment = x.Comment,
                    ExaminationType = x.ExaminationType,
                    LogType = x.LogType,
                    PatientDieseaseId = x.PatientDieseaseId,
                    When = x.When
                };

                int examinationId = -1;
                if (_addExaminationToPatientCommandHandler.Add(examinationModel, ref examinationId).IsSuccess)
                {
                    examinations.Add(examinationModel);
                }
            });
            
            var patient = _patientsDieseasesService.GetPatientById(message.PatientDieseaseId);

            _showToUIHubService.ShowFinalExaminationsResults(examinations, patient.Id);
        }
    }
}