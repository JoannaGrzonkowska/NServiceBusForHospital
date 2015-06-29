using NServiceBus;
using System;

namespace Messages
{
    public interface IDirectorWardMessage:IEvent
    {
        int Id { get; set; }
        string Comment { get; set; }
        DateTime When { get; set; }
    }
}
