using Microsoft.AspNet.SignalR;
using USG.ViewModels;

namespace USG.Hubs.Services
{
    public class ShowToUIHubService : IShowToUIHubService
    {
        private IHubContext _hubContext;

        public ShowToUIHubService()
        {
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<USGHub>();
        }
        public void ShowUSGExamination(USGExaminationViewModel message)
        {
            _hubContext.Clients.All.addNewRequestToUSG(message);
         
        }
    }
}