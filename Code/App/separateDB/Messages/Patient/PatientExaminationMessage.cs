using Messages.Models;
using System;

namespace Messages.Ward
{
    public class PatientExaminationMessage
    {
        public int PatientDieseaseId { get; set; }
        public string Comment { get; set; }
        public DateTime When { get; set; }
        public ExaminationTypeEnum.ExaminationType ExaminationType { get; set; }
        public LogTypeEnum.LogType LogType { get; set; }
    
    }
}
