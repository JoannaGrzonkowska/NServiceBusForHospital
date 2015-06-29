using Messages.Ward;
using NServiceBus;

namespace Messages
{
    public interface IWardUSGExaminationRequest:ICommand
    {
        ExaminationMessage Examination { get; set; }
    }
}
