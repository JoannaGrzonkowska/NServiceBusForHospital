using NServiceBus.Saga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationSaga
{
    public class ZabiegiSagaData : IContainSagaData
    {
        public virtual System.Guid Id { get; set; }
        public virtual String OriginalMessageId { get; set; }
        public virtual String Originator { get; set; }
        public int WynikZLab { get; set; }
        public int IdPacjenta { get; set; }
    }
}