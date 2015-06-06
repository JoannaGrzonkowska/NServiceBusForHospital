using BusinessLogic.CommandHandlers;
using BusinessLogic.Models;
using BusinessLogic.Models.Commands;
using BusinessLogic.Services;
using Ordering.Shared.Common;
using Resources;
using System.Collections.Generic;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers.Api
{
    public class PatientPersonalDataController : ApiController
    {
        private readonly IPatientService _patientService;
        private readonly IAlergyService _alergyService;
        private readonly IAddAlergyToPatientCommandHandler _addAlergyToPatientCommandHandler;
        private readonly IPatientAlergyService _patientAlergyService;

        public PatientPersonalDataController(IPatientService patientService,
            IAlergyService alergyService,
            IAddAlergyToPatientCommandHandler addAlergyToPatientCommandHandler,
            IPatientAlergyService patientAlergyService)
        {
            _patientService = patientService;
            _alergyService = alergyService;
            _addAlergyToPatientCommandHandler = addAlergyToPatientCommandHandler;
            _patientAlergyService = patientAlergyService;
        }

        [HttpGet]
        public PatientPersonalDataViewModel GetPersonalData()
        {
            var patientId = 1;
            var info = _patientService.GetById(patientId);
            var alergyTypes = _alergyService.GetAll();
            var patientAlergies = _patientAlergyService.GetPatientAlergies(patientId);
            var alergyDescriptionMaxLength = LenghtConstraints.AlergyDescriptionMaxLength;
            var patientLocalizations = new PatientLocalizations
               {
                   AlergiesHeader = string.Format(Localizations.PatientsAlergiesHeader, info.Name)
               };

            return new PatientPersonalDataViewModel
           {
               PatientLocalizations = patientLocalizations,
               Info = info,
               AlergyTypes = alergyTypes,
               PatientAlergies = patientAlergies,
               AlergyDescriptionMaxLength = alergyDescriptionMaxLength
           };
        }

        [HttpPost]
        public CommandResult AddAlergy(AddAlergyToPatientCommand command)
        {
            command.PatientId = 1;
            if (command.Description != null && command.Description.Length > LenghtConstraints.AlergyDescriptionMaxLength)
                return new CommandResult(new[]{ 
                    string.Format("Description must be less than {0} characters.", LenghtConstraints.AlergyDescriptionMaxLength) });

            return _addAlergyToPatientCommandHandler.Add(command);
        }

        [HttpGet]
        public IEnumerable<PatientAlergyModel> GetAlergies()
        {
            int patientId = 1;
            return _patientAlergyService.GetPatientAlergies(patientId);
        }
    }
}
