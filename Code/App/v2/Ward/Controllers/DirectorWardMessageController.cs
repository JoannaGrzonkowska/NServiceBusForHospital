using Messages;
using NServiceBus;
using System.Web.Mvc;
using Ward.Hubs.Services;

namespace Ward
{
    public class DirectorWardMessageController : Controller, IHandleMessages<DirectorWardMessage>
    {
        IBus bus;
        private readonly IShowToUIHubService _showToUIHubService;

        public DirectorWardMessageController(IBus bus,
            IShowToUIHubService showToUIHubService)
        {
            this.bus = bus;
            _showToUIHubService = showToUIHubService;
        }

        public void Handle(DirectorWardMessage message)
        {
            _showToUIHubService.ShowPublishedDirectorMessage(message);
        }
    }
}