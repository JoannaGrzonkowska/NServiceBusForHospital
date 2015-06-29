using BusinessLogic.Models;
using Messages;
using Microsoft.AspNet.SignalR;
using RepositoryClasses.Models;
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

        public void ShowPublishedDirectorMessage(DirectorMessagesModel message)
        {
            _hubContext.Clients.All.addPublishedDirectorMessage(message);
        }


        public void ShowFinalExaminationsResults(List<ExaminationsModel> examinationsResults, int patientId)
        {
            _hubContext.Clients.All.addExaminationsResults(examinationsResults, patientId);
        }
    }
}