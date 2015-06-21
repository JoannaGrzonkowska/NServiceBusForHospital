using BusinessLogic.Services;
using Messages;
using Messages.Common;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public HomeController(IBus bus, IShowToUIHubService showToUIHubService,
            IPatientsService patientService)
        {
            _patientsService = patientService;
            _showToUIHubService = showToUIHubService;
            _bus = bus;
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

            var patientInfo = _patientsService.GetById(message.PatientDieseaseId);
            var currentUSGExamination = new USGExaminationCommentViewModel
            {
                USGExaminationComment = message.Comment
            };
            var usgExamination = new USGExaminationViewModel
            {
                PatientInfo = patientInfo,
                USGComment = currentUSGExamination
            };


            _showToUIHubService.ShowUSGExamination(usgExamination);
        }
        [HttpPost]
        public ActionResult SendResultsToWard(USGWardResults message)
        {
            _bus.Send(message);
            return Json(new CommandResult(), JsonRequestBehavior.AllowGet);

        }
    }
}