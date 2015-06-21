using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Messages;
using Messages.Models;

namespace Ward.ViewModels
{
    public class PatientLogViewModel
    {
        public int PatientDieseaseId { get; set; }
        public int PatientId { get; set; }
        public string Comment { get; set; }
        public DateTime When { get; set; }
        public ExaminationTypeEnum.ExaminationType ExaminationType { get; set; }
        public string ExaminationName { get { return ExaminationTypeEnum.GetName(ExaminationType); } }
        public LogTypeEnum.LogType LogType { get; set; }
    }
}