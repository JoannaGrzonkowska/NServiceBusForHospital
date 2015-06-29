using Messages.Ward;
using NServiceBus;

namespace Messages
{
    public interface IWardBloodExaminationRequest : ICommand
    {
        ExaminationMessage Examination { get; set; }
    }
}
