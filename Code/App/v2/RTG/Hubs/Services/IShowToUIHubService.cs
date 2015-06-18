using RTG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTG.Hubs.Services
{
    public interface IShowToUIHubService
    {
        void ShowRTGExamination(RTGExaminationViewModel message);    
    }
}
