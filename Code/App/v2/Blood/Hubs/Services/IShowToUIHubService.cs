using Blood.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blood.Hubs.Services
{
    public interface IShowToUIHubService
    {
        void ShowBloodExamination(BloodExaminationViewModel message);
    }
}