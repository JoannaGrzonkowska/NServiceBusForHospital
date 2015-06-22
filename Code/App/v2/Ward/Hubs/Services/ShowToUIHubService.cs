using Microsoft.AspNet.SignalR;
using Ward.ViewModels;

namespace Ward.Hubs.Services
{
    public class ShowToUIHubService : IShowToUIHubService
    {
        private IHubContext _hubContext;

        public ShowToUIHubService()
        {
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<WardHub>();
        }

        public void ShowWardAcceptance(WardPatientDeclarationViewModel message)
        {
            _hubContext.Clients.All.addNewDeclarationToWard(message);
        }
            
        public void ShowPatientLog(PatientLogViewModel log)
        {
            _hubContext.Clients.All.addNewPatientLog(log);        
        }
    }
}