using System;

namespace Messages.Ward
{
    public class ExaminationMessage
    {
        public int ExtPatientDieseaseId { get; set; }
        public string Comment { get; set; }
        public DateTime When { get; set; }
    }
}
