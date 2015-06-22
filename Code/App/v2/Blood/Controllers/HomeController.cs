using Blood.Hubs.Services;
using Blood.ViewModels;
using BusinessLogic.CommandHandlers;
using BusinessLogic.Models.Commands;
using BusinessLogic.Services;
using Messages;
using Messages.Common;
using NServiceBus;
using System.Web.Mvc;

namespace Blood.Controllers
{
    public class HomeController : Controller,
        IHandleMessages<IWardBloodExaminationRequest>
    {
        private readonly IBus _bus;
        private readonly IPatientsService _patientsService;
        private readonly IShowToUIHubService _showToUIHubService;
        private readonly IPatientsDieseasesService _patientsDieseasesService;
        private readonly IExaminationsService _examinationsService;
        private readonly IAddExaminationToPatientCommandHandler _addExaminationToPatientCommandHandler;

        public HomeController(IBus bus, 
            IShowToUIHubService showToUIHubService,
            IPatientsService patientService,
			IPatientsDieseasesService patientsDieseasesService,
            IExaminationsService examinationsService,
            IAddExaminationToPatientCommandHandler addExaminationToPatientCommandHandler)
        {
            _patientsDieseasesService = patientsDieseasesService;
            _patientsService = patientService;
            _showToUIHubService = showToUIHubService;
            _bus = bus;
            _examinationsService = examinationsService;
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

        public void Handle(IWardBloodExaminationRequest message)
        {
            var patientInfo = _patientsDieseasesService.GetPatientById(message.PatientDieseaseId);
            var examination = _examinationsService.GetById(message.ExaminationId);
            var currentBloodExamination = new BloodExaminationCommentViewModel
            {
                BloodExaminationComment = examination.Comment
            };
            var bloodExamination = new BloodExaminationViewModel
            {
                PatientInfo = patientInfo,
                BloodComment = currentBloodExamination,
                PatientDieseaseId = message.PatientDieseaseId
            };


            _showToUIHubService.ShowBloodExamination(bloodExamination);


        }

        [HttpPost]
        public ActionResult SendToLab(BloodRequestData appData)
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
                BloodLabRequest message = new BloodLabRequest
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