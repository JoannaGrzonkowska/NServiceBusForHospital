using Messages;
using NServiceBus;
using System.Web.Mvc;

namespace Ward.Controllers
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
    }
}