using BusinessLogic.Services;
using Laboratory.Hubs.Services;
using Laboratory.ViewModels;
using Messages;
using Messages.Common;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laboratory.Controllers
{
    public class HomeController : Controller,
        IHandleMessages<IBloodLabRequest>
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


        public void Handle(IBloodLabRequest message)
        {
            var patientInfo = _patientsService.GetById(message.PatientDieseaseId);
            var currentLabExamination = new LabExaminationCommentViewModel
            {
                LabExaminationComment = message.Comment
            };
            var labExamination = new LabExaminationViewModel
            {
                PatientInfo = patientInfo,
                LabComment = currentLabExamination
            };


            _showToUIHubService.ShowLabExamination(labExamination);
        }
        [HttpPost]
        public ActionResult SendResultsToWard(LabWardResults message)
        {
            _bus.Send(message);
            return Json(new CommandResult(), JsonRequestBehavior.AllowGet);

        }
        
    }
}