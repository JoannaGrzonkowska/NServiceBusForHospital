using NServiceBus;

namespace Messages
{
    public interface IUSGWardResults : ICommand
    {
         int ExaminationId { get; set; }
         int PatientDieseaseId { get; set; }
    }
}
