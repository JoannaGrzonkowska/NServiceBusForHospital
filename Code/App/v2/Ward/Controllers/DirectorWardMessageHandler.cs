using Messages;
using NServiceBus;

namespace Ward
{
    public class DirectorWardMessageHandler : IHandleMessages<DirectorWardMessage>
    {
        IBus bus;
        
        public DirectorWardMessageHandler(IBus bus)
        {
            this.bus = bus;
        }

        public void Handle(DirectorWardMessage message)
        {
            //TODO - Do soemthing with message
        }
    }
}