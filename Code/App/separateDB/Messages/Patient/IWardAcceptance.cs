using Messages.Ward;
using NServiceBus;

namespace Messages
{
    public interface IWardAcceptance:ICommand
    {
        PatientMessage Patient { get; set; }
        PatientDieseaseMessage Diesease { get; set; }
    }
}
