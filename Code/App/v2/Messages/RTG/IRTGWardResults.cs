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
        int PatientID { get; set; }
        string Comment { get; set; }
    }
}
