using Messages;
using NServiceBus;
using RepositoryClasses.Models;
using System.Web.Mvc;
using Ward.Hubs.Services;
using WardBusinessLogic.Services;

namespace Ward
{
    public class DirectorWardMessageController : Controller, IHandleMessages<DirectorWardMessage>
    {
        IBus bus;
        private readonly IShowToUIHubService _showToUIHubService;
        private readonly IDirectorMessagesService _directorMessagesService;

        public DirectorWardMessageController(IBus bus,
            IShowToUIHubService showToUIHubService,
            IDirectorMessagesService directorMessagesService)
        {
            this.bus = bus;
            _showToUIHubService = showToUIHubService;
            _directorMessagesService = directorMessagesService;
        }

        public void Handle(DirectorWardMessage message)
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