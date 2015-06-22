
namespace Messages
{
    public class WardBloodExaminationRequest : IWardBloodExaminationRequest
    {
        public int PatientDieseaseId { get; set; }
        public int ExaminationId { get; set; }
    }
}
