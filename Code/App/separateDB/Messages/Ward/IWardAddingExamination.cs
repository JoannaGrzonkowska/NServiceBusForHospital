using NServiceBus;
using System;

namespace Messages
{
    public interface IWardAddingExamination : ICommand
    {
        
        string Comment { get; set; }
        DateTime When { get; set; }
        ExaminationTypeEnum.ExaminationType Type { get; set; }
        int PatientDieseaseId { get; set; }
    }
}