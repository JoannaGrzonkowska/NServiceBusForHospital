using Messages.Ward;

namespace Messages
{
    public class WardBloodExaminationRequest : IWardBloodExaminationRequest
    {
        public ExaminationMessage Examination { get; set; }
    }
}
