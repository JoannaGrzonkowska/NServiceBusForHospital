using NServiceBus;
using Ordering.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Client
{
    public class TestRespondHandler : IHandleMessages<TestRespond>
    {
        IBus bus;

        public TestRespondHandler(IBus bus)
        {
            this.bus = bus;
        }

        public void Handle(TestRespond message)
        {
            Console.WriteLine(@"Response {0}", message.TestMess);
        }
    }
}
