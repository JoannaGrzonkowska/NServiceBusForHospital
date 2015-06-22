using NServiceBus;

namespace Messages
{
    public interface IWardUSGExaminationRequest:ICommand
    {
         int PatientDieseaseId { get; set; }
         int ExaminationId { get; set; }
    }
}
