using Messages;
using Messages.Models;
using System;

namespace RepositoryClasses.Models
{
    public class ExaminationsModel
    {
        public int Id { get; set; }
        public int PatientDieseaseId { get; set; }
        public string Comment { get; set; }
        public DateTime When { get; set; }
        public ExaminationTypeEnum.ExaminationType ExaminationType { get; set; }
        public LogTypeEnum.LogType LogType { get; set; }
    }
}
