using NServiceBus;

namespace Messages
{
    public interface IWardBloodExaminationRequest : ICommand
    {
        int PatientDieseaseId { get; set; }
        int ExaminationId { get; set; }
    }
}
