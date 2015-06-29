using Laboratory.ViewModels;

namespace Laboratory.Hubs.Services
{
    public interface IShowToUIHubService
    {
        void ShowLabExamination(LabExaminationViewModel message);
    
    }
}
