using Messages.Ward;
using NServiceBus;

namespace Messages
{
    public interface IBloodLabRequest : ICommand
    {
        ExaminationMessage Examination { get; set; }
    }
}
