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

        public Results_PatientReciveHandler(IExaminationsService examinationsService, 
            IShowToUIHubService showToUIHubService)
        {
            _examinationsService = examinationsService;
            _showToUIHubService = showToUIHubService;
        }

        public void Handle(IResults_PatientRecive message)
        {
            IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<PatientHub>();
            var examinationsResults = _examinationsService
                .GetExaminationsByPatientDieseaseIdWithFilter(message.PatientDieseaseId, 2);

            _showToUIHubService.ShowFinalExaminationsResults(examinationsResults);
        }
    }
}