using Messages;
using Messages.Common;
using NServiceBus;
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
        public HomeController(IBus bus)
        {
            _bus = bus;
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
        public ActionResult SendMessages(DirectorMessage message)
        {
            object messageToSend;
            if (message.Type == 1)
            {
                messageToSend = new DirectorPatientMessage
                {
                    Content = message.Content
                };
            }
            else
            {
                messageToSend = new DirectorWardMessage
                {
                    Content = message.Content
                };
            }

            _bus.Publish(messageToSend);
            return Json(new CommandResult(), JsonRequestBehavior.AllowGet);
        }
    }
}