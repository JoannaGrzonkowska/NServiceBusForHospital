
namespace Messages
{
    public class BloodLabRequest : IBloodLabRequest
    {
        public int ExaminationId { get; set; }
        public int PatientDieseaseId { get; set; }
    }
}
