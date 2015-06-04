using BusinessLogic.Models.Commands;
using NServiceBus;
using Ordering.Shared;
using Ordering.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationLaboratorium.Controllers
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
            return View();
        }


        public ActionResult Index()
        {
            ViewBag.Message = "Lab";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult WyslijWynikZLab(WynikZLabCommand command)
        {
            try
            {
                var wynikiZLaboratorium = new WynikiZLaboratorium
                {
                    Wynik = command.Wynik,
                    Opis = command.Opis,
                    IdPacjenta = 1
                };
                bus.Send(wynikiZLaboratorium);
            }
            catch (Exception ex)
            {
                new CommandResult(new[] { ex.ToString() });
            }
            return Json(new CommandResult(), JsonRequestBehavior.AllowGet);  
        }
    
    }
}