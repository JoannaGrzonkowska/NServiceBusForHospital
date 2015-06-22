using NServiceBus;

namespace Messages
{
    public interface IResults_PatientRecive : ICommand
    {
        string Comment { get; set; }
        
        int PatientDieseaseId { get; set; }
    }
}
