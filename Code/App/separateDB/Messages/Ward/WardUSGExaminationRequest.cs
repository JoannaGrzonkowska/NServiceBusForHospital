
using Messages.Ward;
namespace Messages
{
    public class WardUSGExaminationRequest : IWardUSGExaminationRequest
    {
        public ExaminationMessage Examination { get; set; }
    }
}
