using BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Patient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPatientsService _patientsService;

        public HomeController(IPatientsService patientsService)
        {
            _patientsService = patientsService;
        }


        public ActionResult Index()
        {
            var patient = _patientsService.GetModelByName(User.Identity.Name);
            return View(patient);
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
    }
}