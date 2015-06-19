using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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