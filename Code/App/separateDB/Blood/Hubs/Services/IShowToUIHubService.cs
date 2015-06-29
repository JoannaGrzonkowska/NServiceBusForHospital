using Blood.ViewModels;

namespace Blood.Hubs.Services
{
    public interface IShowToUIHubService
    {
        void ShowBloodExamination(BloodExaminationViewModel message);
    }
}