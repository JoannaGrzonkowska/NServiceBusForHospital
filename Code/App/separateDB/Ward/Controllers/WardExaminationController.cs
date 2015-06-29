using Messages;
using Messages.Common;
using NServiceBus;
using System.Web.Mvc;
using Ward.Hubs.Services;
using WardBusinessLogic.Services;

namespace Ward.Controllers
{
    public class WardExaminationController : Controller
    {
        private readonly IBus _bus;
        private readonly IDirectorMessagesService _directorMessagesService;

        public WardExaminationController(IBus bus, IDirectorMessagesService directorMessagesService)
        {
            _bus = bus;
            _directorMessagesService = directorMessagesService;
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

        [HttpGet]
        public ActionResult GetDirectorMessages()
        {
            return Json(_directorMessagesService.GetAll(), JsonRequestBehavior.AllowGet);
        }
    }
}