
using Messages.Ward;
namespace Messages
{
    public class BloodLabRequest : IBloodLabRequest
    {
        public ExaminationMessage Examination { get; set; }
    }
}
