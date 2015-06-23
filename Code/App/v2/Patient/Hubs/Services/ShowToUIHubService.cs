using Messages;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patient.Hubs.Services
{
    public class ShowToUIHubService : IShowToUIHubService
    {
        private IHubContext _hubContext;

        public ShowToUIHubService()
        {
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<PatientHub>();
        }

        public void ShowPublishedDirectorMessage(DirectorPatientMessage message)
        {
            _hubContext.Clients.All.addPublishedDirectorMessage(message);
        }
    }
}