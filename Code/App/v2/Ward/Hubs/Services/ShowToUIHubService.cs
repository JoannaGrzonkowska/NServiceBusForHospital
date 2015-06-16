using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ward.ViewModels;

namespace Ward.Hubs.Services
{
    public class ShowToUIHubService : IShowToUIHubService
    {
        private IHubContext _hubContext;

        public ShowToUIHubService()
        {
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<WardHub>();
        }

        public void ShowWardAcceptance(WardPatientDeclarationViewModel message)
        {
            _hubContext.Clients.All.addNewDeclarationToWard(message);
        }

        public void ShowRTGWardResults(Messages.IRTGWardResults message)
        {

        }

        public void ShowUSGWardResults(Messages.IUSGWardResults message)
        {

        }

        public void ShowLabWardResults(Messages.ILabWardResults message)
        {

        }
    }
}