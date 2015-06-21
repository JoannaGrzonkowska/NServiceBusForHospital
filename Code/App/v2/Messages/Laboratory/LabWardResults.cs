using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class LabWardResults : ILabWardResults
    {
        public int ExaminationId { get; set; }
        public int PatientDieseaseId { get; set; }
    }
}
