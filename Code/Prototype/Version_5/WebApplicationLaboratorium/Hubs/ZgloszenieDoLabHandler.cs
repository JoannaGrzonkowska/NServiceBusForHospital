using Microsoft.AspNet.SignalR;
using NServiceBus;
using Ordering.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationLaboratorium.Hubs
{
    public class ZgloszenieDoLabHandler : IHandleMessages<ZgloszenieDoLab>
    {
        public void Handle(ZgloszenieDoLab message)
        {
            IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<TestHub>();
            hubContext.Clients.All.addNewMessageToPage(message.IdPacjenta, message.IdBadania);
        }
    }
}