
using Messages.Ward;
namespace Messages
{
    public class WardRTGExaminationRequest : IWardRTGExaminationRequest
    {
        public ExaminationMessage Examination { get; set; }
    }
}
