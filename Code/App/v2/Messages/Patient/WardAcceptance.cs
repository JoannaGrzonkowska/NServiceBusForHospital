using System;

namespace Messages
{
    public class WardAcceptance:IWardAcceptance
    {
        
        public int DieseaseID { get; set; }
        public DateTime IssueDate { get; set; }
        public string Description { get; set; }
        public int PatientDieseaseId { get; set; }
    }
}
