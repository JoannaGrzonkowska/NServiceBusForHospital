using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class Results_PatientRecive : IResults_PatientRecive
    {
        public string Comment { get; set; }
        public int PatientId { get; set; }
        public int PatientDieseaseId { get; set; }
    }
}
