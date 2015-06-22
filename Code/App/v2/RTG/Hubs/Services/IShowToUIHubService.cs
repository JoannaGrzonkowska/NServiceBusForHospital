using RTG.ViewModels;

namespace RTG.Hubs.Services
{
    public interface IShowToUIHubService
    {
        void ShowRTGExamination(RTGExaminationViewModel message);    
    }
}
