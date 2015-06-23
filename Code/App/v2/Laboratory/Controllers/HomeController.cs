using BusinessLogic.CommandHandlers;
using BusinessLogic.Models.Commands;
using BusinessLogic.Services;
using Laboratory.Hubs.Services;
using Laboratory.ViewModels;
using Messages;
using Messages.Common;
using NServiceBus;
using System.Web.Mvc;

namespace Laboratory.Controllers
{
    public class HomeController : Controller,
        IHandleMessages<IBloodLabRequest>
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
            _addExaminationToPatientCommandHandler = addExaminationToPatientCommandHandler;
            _examinationsService = examinationsService;
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


        public void Handle(IBloodLabRequest message)
        {
            var patientInfo = _patientsDieseasesService.GetPatientById(message.PatientDieseaseId);
            var examination = _examinationsService.GetById(message.ExaminationId);
            var currentLabExamination = new LabExaminationCommentViewModel
            {
                LabExaminationComment = examination.Comment
            };
            var labExamination = new LabExaminationViewModel
            {
                PatientInfo = patientInfo,
                LabComment = currentLabExamination,
                PatientDieseaseId = message.PatientDieseaseId
            };


            _showToUIHubService.ShowLabExamination(labExamination);
        }
        [HttpPost]
        public ActionResult SendResultsToWard(LabRequestData appData)
        {
            int examinationId = -1;
            var addExaminationCommand = _addExaminationToPatientCommandHandler.Add(new AddExaminationToPatientCommand
            {
                PatientDieseaseId = appData.PatientDieseaseId,
                ExaminationType = ExaminationTypeEnum.ExaminationType.LAB,
                LogType = Messages.Models.LogTypeEnum.LogType.Response,
                Comment = appData.Comment
            }, ref examinationId);


            if (addExaminationCommand.IsSuccess)
            {
                LabWardResults message = new LabWardResults
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