using BusinessLogic.CommandHandlers;
using BusinessLogic.Models.Commands;
using BusinessLogic.Services;
using Messages;
using Messages.Common;
using NServiceBus;
using System.Web.Mvc;
using USG.Hubs.Services;
using USG.ViewModels;

namespace USG.Controllers
{
    public class HomeController : Controller,
        IHandleMessages<IWardUSGExaminationRequest>
    {
        private readonly IBus _bus;
        private readonly IPatientsService _patientsService;
        private readonly IShowToUIHubService _showToUIHubService;
        private readonly IPatientsDieseasesService _patientsDieseasesService;
        private readonly IAddExaminationToPatientCommandHandler _addExaminationToPatientCommandHandler;


        public HomeController(IBus bus, 
            IShowToUIHubService showToUIHubService,
            IPatientsService patientService, 
            IPatientsDieseasesService patientsDieseasesService,
            IAddExaminationToPatientCommandHandler addExaminationToPatientCommandHandler)
        {
            _patientsDieseasesService = patientsDieseasesService;
            _patientsService = patientService;
            _showToUIHubService = showToUIHubService;
            _bus = bus;
            _addExaminationToPatientCommandHandler = addExaminationToPatientCommandHandler;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void Handle(IWardUSGExaminationRequest message)
        {
            var patientInfo = _patientsDieseasesService.GetPatientById(message.PatientDieseaseId);
            var currentUSGExamination = new USGExaminationCommentViewModel
            {
                USGExaminationComment = examination.Comment
            };
            var usgExamination = new USGExaminationViewModel
            {
                PatientInfo = patientInfo,
                USGComment = currentUSGExamination
            };

            _showToUIHubService.ShowUSGExamination(usgExamination);
        }
        [HttpPost]
        public ActionResult SendResultsToWard(USGRequestData appData)
        {
            int examinationId = -1;
            var addExaminationCommand = _addExaminationToPatientCommandHandler.Add(new AddExaminationToPatientCommand
            {
                PatientDieseaseId = appData.PatientDieseaseId,
                ExaminationType = ExaminationTypeEnum.ExaminationType.LAB,
                LogType = Messages.Models.LogTypeEnum.LogType.Request,
                Comment = appData.Comment
            }, ref examinationId);


            if (addExaminationCommand.IsSuccess)
            {
                USGWardResults message = new USGWardResults
                {
                    PatientDieseaseId = appData.PatientDieseaseId,
                    ExaminationId = examinationId
                };
                _bus.Send(message);
            }
            return Json(new CommandResult(), JsonRequestBehavior.AllowGet);

        }
    }
}