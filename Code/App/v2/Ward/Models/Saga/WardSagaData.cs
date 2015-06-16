using NServiceBus.Saga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ward.Models;

namespace Ward
{
    public class WardSagaData : IContainSagaData
    {
        public virtual System.Guid Id { get; set; }
        public virtual String OriginalMessageId { get; set; }
        public virtual String Originator { get; set; }
        public List<Examination> Examinations { get; set; }
        public int PatientId { get; set; }

        public WardSagaData()
        {
            Examinations = new List<Examination>();

        }
    }
}