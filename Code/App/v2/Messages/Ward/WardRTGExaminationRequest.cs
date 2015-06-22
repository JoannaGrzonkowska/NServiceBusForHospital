
namespace Messages
{
    public class WardRTGExaminationRequest : IWardRTGExaminationRequest
    {
        public int PatientDieseaseId { get; set; }
        public int ExaminationId { get; set; }
    }
}
