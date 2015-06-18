using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratory.Hubs.Services
{
    public class ShowToUIHubService : IShowToUIHubService
    {
        private IHubContext _hubContext;

        public ShowToUIHubService()
        {
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<LabHub>();
        }

       
        public void ShowLabExamination(ViewModels.LabExaminationViewModel message)
        {
            _hubContext.Clients.All.addNewRequestToLab(message);
        
        }
    }
}