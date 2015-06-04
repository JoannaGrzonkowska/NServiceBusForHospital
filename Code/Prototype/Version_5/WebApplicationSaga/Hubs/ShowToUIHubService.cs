using Microsoft.AspNet.SignalR;
using NServiceBus;
using Ordering.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationSaga.Hubs
{
    public class ShowToUIHubService : IShowToUIHubService
    {
        private IHubContext _hubContext;

        public ShowToUIHubService()
        {
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<TestHub>();
        }

        public void ShowZgloszenieNaWykonanieBadania(ZgloszenieNaWykonanieBadania message)
        {
            _hubContext.Clients.All.addNewMessageToPage("ZgloszenieNaWykonanieBadania pacjent " + message.IdPacjenta, "badanie " + message.IdTypuBadania);
        }

        public void ShowZgloszenieDoLab(ZgloszenieDoLab message)
        {
            _hubContext.Clients.All.addNewMessageToPage("ZgloszenieDoLab pacjent " + message.IdPacjenta, "badanie " + message.IdBadania);
      
        }

        public void ShowWynikiZLaboratorium(WynikiZLaboratorium message)
        {
            _hubContext.Clients.All.addNewMessageToPage("WynikiZLaboratorium pacjent " + message.IdPacjenta, "wynik " + message.Wynik);
      
        }
    }
}