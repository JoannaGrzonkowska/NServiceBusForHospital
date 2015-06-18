using Blood.Hubs.Services;
using Blood.ViewModels;
using BusinessLogic.Services;
using Messages;
using Messages.Common;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blood.Controllers
{
    public class HomeController : Controller,
        IHandleMessages<IWardBloodExaminationRequest>
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

        public void Handle(IWardBloodExaminationRequest message)
        {
            var patientInfo = _patientsService.GetById(message.PatientID);
            var currentBloodExamination = new BloodExaminationCommentViewModel
            {
                BloodExaminationComment = message.Comment
            };
            var bloodExamination = new BloodExaminationViewModel
            {
                PatientInfo = patientInfo,
                BloodComment = currentBloodExamination
            };


            _showToUIHubService.ShowBloodExamination(bloodExamination);


        }
        [HttpPost]
        public ActionResult SendToLab(BloodLabRequest message)
        {
            _bus.Send(message);
            return Json(new CommandResult(), JsonRequestBehavior.AllowGet);

        }
    }
}