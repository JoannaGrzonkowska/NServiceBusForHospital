using BusinessLogic.Services;
using Messages;
using NServiceBus;
using Patient.Hubs.Services;
using RepositoryClasses.Models;
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
        private readonly IDirectorMessagesService _directorMessagesService;

        public DirectorPatientMessageController(IBus bus,
            IShowToUIHubService showToUIHubService,
            IDirectorMessagesService directorMessagesService)
        {
            this.bus = bus;
            _showToUIHubService = showToUIHubService;
            _directorMessagesService = directorMessagesService;
        }

        public void Handle(DirectorPatientMessage message)
        {
            var messageModel = new DirectorMessagesModel
            {
                Comment = message.Comment,
                When = message.When,
                Id = message.Id
            };
            int id = -1;
            if (_directorMessagesService.Add(messageModel, ref id).IsSuccess)
            {
                _showToUIHubService.ShowPublishedDirectorMessage(messageModel);
            }
        }
    }
}