using Messages.Ward;
using System.Collections;
using System.Collections.Generic;

namespace Messages
{
    public class Results_PatientRecive : IResults_PatientRecive
    {        
        public int PatientDieseaseId { get; set; }
        public List<PatientExaminationMessage> Examinations { get; set; }
    }
}
