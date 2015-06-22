using Messages;
using NServiceBus;
using Patient.Hubs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Patient.Controllers
{
    public class DirectorPatientMessageController : Controller, IHandleMessages<DirectorPatientMessage>
    {
         IBus bus;
        private readonly IShowToUIHubService _showToUIHubService;

        public DirectorPatientMessageController(IBus bus,
            IShowToUIHubService showToUIHubService)
        {
            this.bus = bus;
            _showToUIHubService = showToUIHubService;
        }

        public void Handle(DirectorPatientMessage message)
        {
            _showToUIHubService.ShowPublishedDirectorMessage(message);
        }
    }
}