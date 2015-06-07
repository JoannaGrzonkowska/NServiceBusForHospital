using BusinessLogic.CommandHandlers;
using BusinessLogic.Models;
using BusinessLogic.Models.Commands;
using BusinessLogic.Services;
using Ordering.Shared.Common;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class PatientPersonalDataController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IAlergyService _alergyService;
        private readonly IAddAlergyToPatientCommandHandler _addAlergyToPatientCommandHandler;
        private readonly IPatientAlergyService _patientAlergyService;
        private readonly IAccountService _accountService;

        public PatientPersonalDataController(IPatientService patientService,
            IAlergyService alergyService,
            IAddAlergyToPatientCommandHandler addAlergyToPatientCommandHandler,
            IPatientAlergyService patientAlergyService,
            IAccountService accountService)
        {
            _patientService = patientService;
            _alergyService = alergyService;
            _addAlergyToPatientCommandHandler = addAlergyToPatientCommandHandler;
            _patientAlergyService = patientAlergyService;
            _accountService = accountService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult GetPersonalData()
        {
            var patient = _patientService.GetModelByName(User.Identity.Name);

            var patientId = patient.Id;
            var info = _patientService.GetById(patientId);
            var alergyTypes = _alergyService.GetAll();
            var patientAlergies = _patientAlergyService.GetPatientAlergies(patientId);
            var alergyDescriptionMaxLength = LenghtConstraints.AlergyDescriptionMaxLength;
            var patientLocalizations = new PatientLocalizations
               {
                   AlergiesHeader = string.Format(Localizations.PatientsAlergiesHeader, info.Name)
               };

            return Json(new PatientPersonalDataViewModel
           {
               PatientLocalizations = patientLocalizations,
               Info = info,
               AlergyTypes = alergyTypes,
               PatientAlergies = patientAlergies,
               AlergyDescriptionMaxLength = alergyDescriptionMaxLength,
           }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddAlergy(AddAlergyToPatientCommand command)
        {
            var patient = _patientService.GetModelByName(User.Identity.Name);
            command.PatientId = patient.Id;
            if (command.Description != null && command.Description.Length > LenghtConstraints.AlergyDescriptionMaxLength)
                return Json(new CommandResult(new[]{ 
                    string.Format("Description must be less than {0} characters.", LenghtConstraints.AlergyDescriptionMaxLength) }),
                    JsonRequestBehavior.AllowGet);

            return Json(_addAlergyToPatientCommandHandler.Add(command), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetAlergies()
        {
            var patient = _patientService.GetModelByName(User.Identity.Name);
            return Json(_patientAlergyService.GetPatientAlergies(patient.Id), JsonRequestBehavior.AllowGet);
        }
    }
}