using Blood.ViewModels;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blood.Hubs.Services
{
    public class ShowToUIHubService : IShowToUIHubService
    {
        private IHubContext _hubContext;

        public ShowToUIHubService()
        {
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<BloodHub>();
        }

        void IShowToUIHubService.ShowBloodExamination(BloodExaminationViewModel message)
        {
            _hubContext.Clients.All.addNewRequestToBlood(message);
        }
    }
}