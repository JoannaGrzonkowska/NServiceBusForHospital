using NServiceBus;

namespace Messages
{
    public interface IWardAddingExamination : ICommand
    {
        int PatientID { get; set; }
        string Comment { get; set; }
        ExaminationType Type { get; set; }
    }
}