using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class WardAcceptance:IWardAcceptance
    {
        public int PatientID { get; set; }
        public int DieseaseID { get; set; }
        public DateTime IssueDate { get; set; }
        public string Description { get; set; }
    }
}
