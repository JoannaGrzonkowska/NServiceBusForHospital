using Messages.Ward;
using NServiceBus;

namespace Messages
{
    public interface IWardRTGExaminationRequest : ICommand
    {
        ExaminationMessage Examination { get; set; }
    }
}
