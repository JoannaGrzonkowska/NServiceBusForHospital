using Microsoft.AspNet.SignalR;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Hubs
{
    public class EventMessageHandler : IHandleMessages<OrderPlaced>
    {
        public void Handle(OrderPlaced message)
        {
            IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<TestHub>();
            hubContext.Clients.All.addNewMessageToPage(message.OrderId, "Jaliya");
        }
    }
}