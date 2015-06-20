using BusinessLogic.CommandHandlers;
using BusinessLogic.Models.Commands;
using BusinessLogic.Services;
using Messages;
using Messages.Common;
using NServiceBus;
using Patient.Models;
using Patient.ViewModels;
using System;
using System.Web.Mvc;

namespace Patient.Controllers
{
    public class PatientPersonalDataController : Controller
    {
        private readonly IPatientsService _patientsService;
        private readonly IDieseasesService _dieseasesService;
        private readonly IAddDieseaseToPatientCommandHandler _addDieseaseToPatientCommandHandler;
        private readonly IPatientsDieseasesService _patientsDieseasesService;
        private readonly IAccountService _accountService;
        private readonly IBus _bus;
        
        public PatientPersonalDataController(IPatientsService patientService,
            IDieseasesService dieseasesService,
            IAddDieseaseToPatientCommandHandler addDieseaseToPatientCommandHandler,
            IPatientsDieseasesService patientDieseasesService,
            IAccountService accountService,
            IBus bus)
        {
            _patientsService = patientService;
            _dieseasesService = dieseasesService;
            _addDieseaseToPatientCommandHandler = addDieseaseToPatientCommandHandler;
            _patientsDieseasesService = patientDieseasesService;
            _accountService = accountService;
            _bus = bus;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
      //  [Authorize]
        public ActionResult GetPersonalData()
        {
     //       var patient = _patientsService.GetModelByName(User.Identity.Name);

            var patientId = 2;//patient.Id;
            var info = _patientsService.GetById(patientId);
            var dieseasesTypes = _dieseasesService.GetAll();
            var patientDieseases = _patientsDieseasesService.GetPatientsDieseases(patientId);
            var dieseaseDescriptionMaxLength = LengthConstraints.DieseasesDescriptionMaxLength;
            

            return Json(new PatientPersonalDataViewModel
           {
               
               Info = info,
               DieseasesTypes = dieseasesTypes,
               PatientDieseases = patientDieseases,
               DieseaseDescriptionMaxLength = dieseaseDescriptionMaxLength,
           }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddDiesease(AddDieseaseToPatientCommand command)
        {
//               var patient = _patientsService.GetModelByName(User.Identity.Name);
            command.PatientId = 2;//patient.Id;
            if (command.Description != null && command.Description.Length > LengthConstraints.DieseasesDescriptionMaxLength)
                return Json(new CommandResult(new[]{ 
                    string.Format("Description must be less than {0} characters.", LengthConstraints.DieseasesDescriptionMaxLength) }),
                    JsonRequestBehavior.AllowGet);

            int patientDieseaseId = -1;
            var addDieseaseCommand = _addDieseaseToPatientCommandHandler.Add(command, ref patientDieseaseId);

            if (addDieseaseCommand.IsSuccess)
            {
                //test message
                var resultsMessage = new WardAcceptance
                {
                    PatientID = 2, 
                    DieseaseID = command.DieseaseId,
                    IssueDate = DateTime.Now,
                    Description = command.Description,
                    PatientDieseaseId = patientDieseaseId
                };
                _bus.Send(resultsMessage);
                addDieseaseCommand = new CommandResult();
            }

            return Json(addDieseaseCommand, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetPatientDieseases()
        {
           // var patient = _patientsService.GetModelByName(User.Identity.Name);
            return Json(_patientsDieseasesService.GetPatientsDieseases(2/*patient.Id*/), JsonRequestBehavior.AllowGet);
        }
    
    }
}