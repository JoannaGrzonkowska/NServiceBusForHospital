using NServiceBus;

namespace Messages
{
    public interface IWardRTGExaminationRequest : ICommand
    {
         int PatientDieseaseId { get; set; }
         int ExaminationId { get; set; }
    }
}
