using BusinessLogic.Services;
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
            try
            {
                var patient = _patientsService.GetModelByName(User.Identity.Name);

                return View(patient);
            }
            catch
            {
                return RedirectToAction("Login", "Patient");
            }
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