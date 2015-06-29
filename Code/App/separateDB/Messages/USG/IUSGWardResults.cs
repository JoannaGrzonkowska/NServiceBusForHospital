using Messages.Ward;
using NServiceBus;

namespace Messages
{
    public interface IUSGWardResults : ICommand
    {
        ExaminationMessage Examination { get; set; }
    }
}
