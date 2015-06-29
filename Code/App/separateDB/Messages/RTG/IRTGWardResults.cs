using Messages.Ward;
using NServiceBus;

namespace Messages
{
    public interface IRTGWardResults : ICommand
    {
        ExaminationMessage Examination { get; set; }
    }
}
