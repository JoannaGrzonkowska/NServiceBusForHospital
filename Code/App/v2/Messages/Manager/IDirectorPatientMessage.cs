using NServiceBus;

namespace Messages
{
    public interface IDirectorPatientMessage
    {
        string Content { get; set; }
    }
}
