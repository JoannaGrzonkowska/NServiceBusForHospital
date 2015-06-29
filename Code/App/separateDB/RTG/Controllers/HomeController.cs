using Messages;
using Messages.Common;
using Messages.Models;
using Messages.Ward;
using NServiceBus;
using RTG.Hubs.Services;
using RTG.ViewModels;
using RtgBusinessLogic.Services;
using System;
using System.Web.Mvc;

namespace RTG.Controllers
{
    public class HomeController : Controller,
        IHandleMessages<IWardRTGExaminationRequest>
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

        public void Handle(IWardRTGExaminationRequest message)
        {
            int examinationId = -1;

            if (!_examinationsService.Add(message.Examination, LogTypeEnum.LogType.Request, ref examinationId).IsSuccess)
            {
                return;
            }
            var currentRTGExamination = new RTGExaminationCommentViewModel
            {
                RTGExaminationComment = message.Examination.Comment
            };
            var rtgExamination = new RTGExaminationViewModel
            {
                RTGComment = currentRTGExamination,
                PatientDieseaseId = message.Examination.ExtPatientDieseaseId
            };
            
            _showToUIHubService.ShowRTGExamination(rtgExamination);
        }
        [HttpPost]
        public ActionResult SendResultsToWard(RTGRequestData appData)
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
                RTGWardResults message = new RTGWardResults
                {
                    Examination = examinationMessage
                };
                _bus.Send(message);
            return Json(new CommandResult(), JsonRequestBehavior.AllowGet);
    }
    }
}