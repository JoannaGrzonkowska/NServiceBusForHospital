using NServiceBus;

namespace Messages
{
    public interface IRTGWardResults : ICommand
    {
         int ExaminationId { get; set; }
         int PatientDieseaseId { get; set; }
    }
}
