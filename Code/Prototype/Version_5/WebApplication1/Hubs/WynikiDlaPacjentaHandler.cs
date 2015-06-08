
using Microsoft.AspNet.SignalR;
using NServiceBus;
using Ordering.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Hubs
{
    public class WynikiDlaPacjentaHandler : IHandleMessages<WynikiDlaPacjenta>
    {
        public void Handle(WynikiDlaPacjenta message)
        {
           
            IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<TestHub>();
            hubContext.Clients.All.addNewMessageToPage("Wynik",message.Wynik);
        }
    }
}