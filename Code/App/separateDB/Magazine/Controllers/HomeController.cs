using DirectorBusinessLogic.Services;
using Messages;
using Messages.Common;
using NServiceBus;
using RepositoryClasses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Magazine.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBus _bus;
        private readonly IDirectorMessagesService _directorMessagesService;

        public HomeController(IBus bus,
            IDirectorMessagesService directorMessagesService)
        {
            _bus = bus;
            _directorMessagesService = directorMessagesService;
        }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult SendMessages(DirectorMessagesModel message)
        {
            object messageToSend;

            int messageId = -1;
            message.When = DateTime.Now;
            if (!_directorMessagesService.Add(message, ref messageId).IsSuccess)
            {
                return Json(new CommandResult(new[] { "Insert to db failed" }), JsonRequestBehavior.AllowGet);
            }
            message.Id = messageId;

            if (message.Type == 0)
            {
                messageToSend = new DirectorPatientMessage
                {
                    Id = message.Id,
                    Comment = message.Comment,
                    When = message.When
                };
            }
            else
            {
                messageToSend = new DirectorWardMessage
                {
                    Id = message.Id,
                    Comment = message.Comment,
                    When = message.When
                };
            }

            _bus.Publish(messageToSend);
            return Json(new CommandResult(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetMessages()
        {
            return Json(_directorMessagesService.GetAll(), JsonRequestBehavior.AllowGet);
        }
    }
}