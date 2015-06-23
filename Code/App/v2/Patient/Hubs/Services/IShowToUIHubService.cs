using BusinessLogic.Models;
using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Hubs.Services
{
    public interface IShowToUIHubService
    {
        void ShowPublishedDirectorMessage(DirectorPatientMessage message);
        void ShowFinalExaminationsResults(List<ExaminationsModel> examinationsResults);
    
    }
}
