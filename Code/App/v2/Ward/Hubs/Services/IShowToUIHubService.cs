using Messages;
using Ward.ViewModels;

namespace Ward.Hubs.Services
{
    public interface IShowToUIHubService
    {
        void ShowWardAcceptance(WardPatientDeclarationViewModel message);
        void ShowPatientLog(PatientLogViewModel log);
        void ShowPublishedDirectorMessage(DirectorWardMessage message);
    }
}