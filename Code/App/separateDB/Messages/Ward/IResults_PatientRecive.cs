using Messages.Ward;
using NServiceBus;
using System.Collections.Generic;

namespace Messages
{
    public interface IResults_PatientRecive : ICommand
    {        
        int PatientDieseaseId { get; set; }
        List<PatientExaminationMessage> Examinations { get; set; }
    }
}
