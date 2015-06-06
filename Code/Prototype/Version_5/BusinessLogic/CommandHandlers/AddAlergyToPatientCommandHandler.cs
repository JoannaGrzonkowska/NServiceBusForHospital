using BusinessLogic.Models.Commands;
using DataAccess;
using DataAccess.Repositories;
using Ordering.Shared.Common;
using System;

namespace BusinessLogic.CommandHandlers
{
   public class AddAlergyToPatientCommandHandler : IAddAlergyToPatientCommandHandler
    {
       private readonly IPatientAlergyRepository _patientAlergyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddAlergyToPatientCommandHandler(
            IPatientAlergyRepository patientAlergyRepository,
            IUnitOfWork unitOfWork)
        {
            _patientAlergyRepository = patientAlergyRepository;
            _unitOfWork = unitOfWork;
        }

         public CommandResult Add(AddAlergyToPatientCommand command)
        {
            var patientAlergy = new PatientAlergies
            {
               AlergyId = command.AlergyId,
               PatientId = command.PatientId,
               Description = command.Description,
               WhenDiagnosed = DateTime.Now
            };
            _patientAlergyRepository.Add(patientAlergy);
            _unitOfWork.SaveChanges();

            return new CommandResult();
        }
    }
}
