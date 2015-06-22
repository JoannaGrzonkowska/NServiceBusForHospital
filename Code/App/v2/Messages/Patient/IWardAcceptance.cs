using NServiceBus;
using System;

namespace Messages
{
    public interface IWardAcceptance:ICommand
    {
        
        int DieseaseID { get; set; }
        DateTime IssueDate { get; set; }
        string Description { get; set; }
        int PatientDieseaseId { get; set; }
    }
}
