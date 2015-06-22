using NServiceBus;

namespace Messages
{
    public interface IDirectorPatientMessage
    {
        int MessageId { get; set; }
        string Content { get; set; }
    }
}
