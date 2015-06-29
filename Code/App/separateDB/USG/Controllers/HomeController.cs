using Messages;
using Messages.Common;
using Messages.Models;
using Messages.Ward;
using NServiceBus;
using System;
using System.Web.Mvc;
using USG.Hubs.Services;
using USG.ViewModels;
using UsgBusinessLogic.Services;

namespace USG.Controllers
{
    public class HomeController : Controller,
        IHandleMessages<IWardUSGExaminationRequest>
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

        public void Handle(IWardUSGExaminationRequest message)
        {
            int examinationId = -1;

            if (!_examinationsService.Add(message.Examination, LogTypeEnum.LogType.Request, ref examinationId).IsSuccess)
            {
                return;
            }

            var usgExamination = new USGExaminationViewModel
            {
                USGComment = new USGExaminationCommentViewModel
                {
                    USGExaminationComment = message.Examination.Comment
                },
                PatientDieseaseId = message.Examination.ExtPatientDieseaseId
            };

            _showToUIHubService.ShowUSGExamination(usgExamination);
        }
        [HttpPost]
        public ActionResult SendResultsToWard(USGRequestData appData)
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
            USGWardResults message = new USGWardResults
            {
                Examination = examinationMessage
            };
            _bus.Send(message);
            return Json(new CommandResult(), JsonRequestBehavior.AllowGet);
        }
    }
}