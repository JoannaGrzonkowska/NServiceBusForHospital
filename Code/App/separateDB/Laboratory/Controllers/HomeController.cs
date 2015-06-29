using LabBusinessLogic.Services;
using Laboratory.Hubs.Services;
using Laboratory.ViewModels;
using Messages;
using Messages.Common;
using Messages.Models;
using Messages.Ward;
using NServiceBus;
using System;
using System.Web.Mvc;

namespace Laboratory.Controllers
{
    public class HomeController : Controller,
        IHandleMessages<IBloodLabRequest>
    {
        private readonly IBus _bus;
        private readonly IShowToUIHubService _showToUIHubService;
        private readonly IExaminationsService _examinationsService;
     
        public HomeController(IBus bus,
            IShowToUIHubService showToUIHubService,
            IExaminationsService examinationsService)
        {
            _showToUIHubService = showToUIHubService;
            _bus = bus;
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
            int examinationId = -1;

            if (!_examinationsService.Add(message.Examination, LogTypeEnum.LogType.Request, ref examinationId).IsSuccess)
            {
                return;
            }

            var currentLabExamination = new LabExaminationCommentViewModel
            {
                LabExaminationComment = message.Examination.Comment
            };
            var labExamination = new LabExaminationViewModel
            {
                LabComment = currentLabExamination,
                PatientDieseaseId = message.Examination.ExtPatientDieseaseId
            };

            _showToUIHubService.ShowLabExamination(labExamination);
        }
        [HttpPost]
        public ActionResult SendResultsToWard(LabRequestData appData)
        {
            var examinationMessage = new ExaminationMessage
            {
                Comment = appData.Comment,
                ExtPatientDieseaseId = appData.PatientDieseaseId,
                When = DateTime.Now
            };

            int examinationId = -1;

            if (!_examinationsService.Add(examinationMessage, LogTypeEnum.LogType.Response, ref examinationId).IsSuccess)
            {
                return Json(new CommandResult(new[] { "Saving to db failed" }), JsonRequestBehavior.AllowGet);
            }
                LabWardResults message = new LabWardResults
                {
                    Examination = examinationMessage
                };
                _bus.Send(message);
            return Json(new CommandResult(), JsonRequestBehavior.AllowGet);

        }
        
    }
}