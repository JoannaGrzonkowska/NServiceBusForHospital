using BusinessLogic.CommandHandlers;
using BusinessLogic.Models.Commands;
using BusinessLogic.Services;
using Messages;
using Messages.Common;
using NServiceBus;
using RTG.Hubs.Services;
using RTG.ViewModels;
using System.Web.Mvc;

namespace RTG.Controllers
{
    public class HomeController : Controller,
        IHandleMessages<IWardRTGExaminationRequest>
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

        public void Handle(IWardRTGExaminationRequest message)
        {
            var patientInfo = _patientsDieseasesService.GetPatientById(message.PatientDieseaseId);
            var examination = _examinationsService.GetById(message.ExaminationId);

            var currentRTGExamination = new RTGExaminationCommentViewModel
            {
                RTGExaminationComment = examination.Comment
            };
            var rtgExamination = new RTGExaminationViewModel
            {
                PatientInfo = patientInfo,
                RTGComment = currentRTGExamination,
                PatientDieseaseId = message.PatientDieseaseId
            };
            
            _showToUIHubService.ShowRTGExamination(rtgExamination);
        }
        [HttpPost]
        public ActionResult SendResultsToWard(RTGRequestData appData)
        {
            int examinationId = -1;
            var addExaminationCommand = _addExaminationToPatientCommandHandler.Add(new AddExaminationToPatientCommand
            {
                PatientDieseaseId = appData.PatientDieseaseId,
                ExaminationType = ExaminationTypeEnum.ExaminationType.RTG,
                LogType = Messages.Models.LogTypeEnum.LogType.Response,
                Comment = appData.Comment
            }, ref examinationId);


            if (addExaminationCommand.IsSuccess)
            {
                RTGWardResults message = new RTGWardResults
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