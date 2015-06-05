using NServiceBus;
using Ordering.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ordering.Shared.Extensions;
using BusinessLogic.Services;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

         IBus bus;
         private readonly IPatientService _patientService;


         public HomeController(IBus bus, IPatientService patientService)
    {
        this.bus = bus;
        _patientService = patientService;
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
            IEnumerable<WynikiDlaPacjenta> test = new List<WynikiDlaPacjenta>(){
                 new WynikiDlaPacjenta{ Wynik=1},
                 new WynikiDlaPacjenta{ Wynik=2},
                 new WynikiDlaPacjenta{ Wynik=3}
             };

            var filtered = test.Filter<WynikiDlaPacjenta>(x => x.Wynik > 2);



            var t = _patientService.TestMethod1_1(2);

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