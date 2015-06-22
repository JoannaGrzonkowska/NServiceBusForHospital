
using NServiceBus;
namespace Messages
{
    public interface IDirectorWardMessage:IEvent
    {
        string Content { get; set; }
    }
}
