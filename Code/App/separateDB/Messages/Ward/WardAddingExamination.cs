using System;

namespace Messages
{
    public class WardAddingExamination : IWardAddingExamination
    {
        
        public string Comment { get; set; }
        public DateTime When { get; set; }
        public ExaminationTypeEnum.ExaminationType Type { get; set; }
        public int PatientDieseaseId { get; set; }
    }
}
