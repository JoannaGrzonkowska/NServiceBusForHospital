using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages.Interfaces;
using NServiceBus;

namespace Messages.Classes
{
    class RTGWardResults : IEvent, IRTGWardResults
    {
        public int PatientId { get; set; }

        public string Comment { get; set; }
    }
}
