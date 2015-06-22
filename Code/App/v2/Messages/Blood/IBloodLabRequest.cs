using NServiceBus;

namespace Messages
{
    public interface IBloodLabRequest : ICommand
    {
         int ExaminationId { get; set; }
         int PatientDieseaseId { get; set; }
    }
}
