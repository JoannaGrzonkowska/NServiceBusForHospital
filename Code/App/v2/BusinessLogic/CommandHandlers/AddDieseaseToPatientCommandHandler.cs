using BusinessLogic.Models.Commands;
using DataAccess;
using DataAccess.Repositories;
using Messages.Common;
using System;

namespace BusinessLogic.CommandHandlers
{
    public class AddDieseaseToPatientCommandHandler : IAddDieseaseToPatientCommandHandler
    {
        private readonly IPatientsDieseasesRepository _patientsDieseasesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddDieseaseToPatientCommandHandler(
            IPatientsDieseasesRepository patientsDieseasesRepository,
            IUnitOfWork unitOfWork)
        {
            _patientsDieseasesRepository = patientsDieseasesRepository;
            _unitOfWork = unitOfWork;
        }

        public CommandResult Add(AddDieseaseToPatientCommand command, ref int patientDieseaseId)
        {
            var patientAlergy = new PatientsDieseases
            {
                DieseaseId = command.DieseaseId,
                PatientId = command.PatientId,
                Description = command.Description
            };
            _patientsDieseasesRepository.Add(patientAlergy);
            _unitOfWork.SaveChanges();

            patientDieseaseId = patientAlergy.Id;

            return new CommandResult();
        }
    }
}
