using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public interface IWardRTGExaminationRequest : ICommand
    {
         int PatientDieseaseId { get; set; }
         int ExaminationId { get; set; }
    }
}
