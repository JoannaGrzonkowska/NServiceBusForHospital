using NServiceBus;

namespace Messages
{
    public interface IDirectorPatientMessage : IEvent
    {
        string Content { get; set; }
    }
}
