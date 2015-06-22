using NServiceBus;

namespace Messages
{
    public interface ILabWardResults : ICommand
    {
        int ExaminationId { get; set; }
        int PatientDieseaseId { get; set; }
    }
}
