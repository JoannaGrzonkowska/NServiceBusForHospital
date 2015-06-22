using Messages;
using Microsoft.AspNet.SignalR;
using NServiceBus;

namespace Patient.Hubs
{
    public class Results_PatientReciveHandler : IHandleMessages<IResults_PatientRecive>
    {
        public void Handle(IResults_PatientRecive message)
        {
            IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<PatientHub>();


            hubContext.Clients.All.addNewMessageToPage("Comment", message.Comment);//TODO + 1 kalsa + id pacjetna
        }
    }
}