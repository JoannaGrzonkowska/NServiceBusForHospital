using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public interface IUSGWardResults : ICommand
    {
         int ExaminationId { get; set; }
         int PatientDieseaseId { get; set; }
    }
}
