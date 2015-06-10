using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages.Interfaces;

namespace Messages.Classes
{
    class PatientWardAcceptance : IPatientWardAcceptance
    {
        public int PatientId {get; set;}
        public DateTime IssueDate { get; set; }
    }
}
