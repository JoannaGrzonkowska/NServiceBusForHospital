using Laboratory.ViewModels;
using Microsoft.AspNet.SignalR;

namespace Laboratory.Hubs.Services
{
    public class ShowToUIHubService : IShowToUIHubService
    {
        private IHubContext _hubContext;

        public ShowToUIHubService()
        {
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<LabHub>();
        }

       
        public void ShowLabExamination(LabExaminationViewModel message)
        {
            _hubContext.Clients.All.addNewRequestToLab(message);
        
        }
    }
}