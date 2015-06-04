using NServiceBus;
using Ordering.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

         IBus bus;

         public HomeController(IBus bus)
    {
        this.bus = bus;
    }


         public ActionResult About()
         {
             var zgloszenieNaWykonanieBadania = new ZgloszenieNaWykonanieBadania
             {
                 IdTypuBadania = 1,
                 IdPacjenta = 1
             };
             bus.Send(zgloszenieNaWykonanieBadania);

             return View();
         }

         public ActionResult Index()
        {
            ViewBag.Message = "Pacjent";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}