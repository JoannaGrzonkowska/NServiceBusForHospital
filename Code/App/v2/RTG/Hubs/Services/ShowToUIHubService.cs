using Microsoft.AspNet.SignalR;
using RTG.ViewModels;

namespace RTG.Hubs.Services
{
    public class ShowToUIHubService : IShowToUIHubService
    {
        private IHubContext _hubContext;

        public ShowToUIHubService()
        {
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<RTGHub>();
        }

        public void ShowRTGExamination(RTGExaminationViewModel message)
        {
            _hubContext.Clients.All.addNewRequestToRTG(message);
         
        }
    }
}