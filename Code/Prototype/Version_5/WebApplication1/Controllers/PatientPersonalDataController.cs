using BusinessLogic.Models.Commands;
using BusinessLogic.Services;
using Ordering.Shared.Common;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class PatientPersonalDataController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientPersonalDataController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // GET: PatientPersonalData
        public ActionResult Index()
        {
            return View();
        }

         [HttpGet]
        public ActionResult GetPersonalData()
        {
            return Json(new PatientPersonalDataViewModel
            {
                PatientLocalizations = new PatientLocalizations
                {
                    AlergiesHeader = string.Format(Localizations.PatientsAlergiesHeader, "Ktos")
                },
                Info = new PatientInfoViewModel
                {
                    Age = 20,
                    Name = "Ktos"
                },
                AlergyTypes = new List<AlergyTypeViewModel>(){
                     new AlergyTypeViewModel{
                         Id = 1,
                         Name = "a1"
                     },
                     new AlergyTypeViewModel{
                         Id = 2,
                         Name = "a2"
                     }
                 },
                PatientAlergies = new List<PatientAlergyViewModel>(){
                     new PatientAlergyViewModel{
                         AlergyId = 1,
                         AlergyName = "a",
                         Description = "desc1",
                         WhenDiagnosed = DateTime.Now
                     },
                     new PatientAlergyViewModel{
                         AlergyId = 2,
                         AlergyName = "a2",
                         Description = "desc2",
                         WhenDiagnosed = DateTime.Now
                     }
                 },
                AlergyDescriptionMaxLength = 200,
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
         public ActionResult AddAlergy(AddAlergyToPatientCommand command)
        {
            return Json(new CommandResult(), JsonRequestBehavior.AllowGet);
        }

         [HttpGet]
        public ActionResult GetAlergies()
        {
             return Json( new List<PatientAlergyViewModel>(){
                     new PatientAlergyViewModel{
                         AlergyId = 1,
                         AlergyName = "a",
                         Description = "desc1",
                         WhenDiagnosed = DateTime.Now
                     },
                     new PatientAlergyViewModel{
                         AlergyId = 2,
                         AlergyName = "a2",
                         Description = "desc2",
                         WhenDiagnosed = DateTime.Now
                     }
             }, JsonRequestBehavior.AllowGet);
        }
    }
}