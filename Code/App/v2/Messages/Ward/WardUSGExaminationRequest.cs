
namespace Messages
{
    public class WardUSGExaminationRequest : IWardUSGExaminationRequest
    {
        public int PatientDieseaseId { get; set; }
        public int ExaminationId { get; set; }
    }
}
