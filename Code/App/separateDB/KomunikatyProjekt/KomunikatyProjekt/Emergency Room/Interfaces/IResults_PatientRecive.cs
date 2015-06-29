using NServiceBus;

namespace KomunikatyProjekt.Emergency_Room.Interfaces
{
    public interface IResults_PatientRecive:ICommand
    {
        string Comment { get; set; }
    }
}
