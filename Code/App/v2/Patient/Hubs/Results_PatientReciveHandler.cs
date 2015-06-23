using BusinessLogic.Services;
using Messages;
using Microsoft.AspNet.SignalR;
using NServiceBus;
using Patient.Hubs.Services;

namespace Patient.Hubs
{
    public class Results_PatientReciveHandler : IHandleMessages<IResults_PatientRecive>
    {
        private readonly IExaminationsService _examinationsService;
        private readonly IShowToUIHubService _showToUIHubService;
        private readonly IPatientsDieseasesService _patientsDieseasesService;
        
        public Results_PatientReciveHandler(IExaminationsService examinationsService, 
            IShowToUIHubService showToUIHubService,
            IPatientsDieseasesService patientsDieseasesService)
        {
            _examinationsService = examinationsService;
            _showToUIHubService = showToUIHubService;
            _patientsDieseasesService = patientsDieseasesService;
        }

        public void Handle(IResults_PatientRecive message)
        {
            IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<PatientHub>();
            var examinationsResults = _examinationsService
                .GetExaminationsByPatientDieseaseIdWithFilter(message.PatientDieseaseId);

            var patient = _patientsDieseasesService.GetPatientById(message.PatientDieseaseId);

            _showToUIHubService.ShowFinalExaminationsResults(examinationsResults, patient.Id);
        }
    }
}