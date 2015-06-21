using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public interface IRTGWardResults : ICommand
    {
        
        string Comment { get; set; }
        int PatientDieseaseId { get; set; }
    }
}
