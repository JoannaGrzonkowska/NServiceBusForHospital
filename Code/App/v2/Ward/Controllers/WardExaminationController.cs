using Messages;
using Messages.Common;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ward.Controllers
{
    public class WardExaminationController : Controller
    {
        private readonly IBus _bus;
        public WardExaminationController(IBus bus)
        {
            _bus = bus;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendToExamination(WardAddingExamination message)
        {

            _bus.SendLocal(message);
            return Json(new CommandResult(), JsonRequestBehavior.AllowGet);
        }

    }
}