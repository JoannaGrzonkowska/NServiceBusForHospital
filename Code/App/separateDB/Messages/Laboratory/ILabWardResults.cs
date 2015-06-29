using Messages.Ward;
using NServiceBus;

namespace Messages
{
    public interface ILabWardResults : ICommand
    {
        ExaminationMessage Examination { get; set; }
    }
}
