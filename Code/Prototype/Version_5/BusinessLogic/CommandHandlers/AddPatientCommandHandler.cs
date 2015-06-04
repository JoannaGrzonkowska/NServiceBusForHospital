using BusinessLogic.Models.Commands;
using DataAccess;
using DataAccess.Repositories;
using Ordering.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.CommandHandlers
{
    public class AddPatientCommandHandler : IAddPatientCommandHandler
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddPatientCommandHandler(
            IPatientRepository patientRepository,
            IUnitOfWork unitOfWork)
        {
            _patientRepository = patientRepository;
            _unitOfWork = unitOfWork;
        }

        public CommandResult Add(AddPatientCommand command)
        {
            var patient = new Patient
            {
                Name = command.Name
            };
            _patientRepository.Add(patient);
            _unitOfWork.SaveChanges();

            return new CommandResult();
        }
    }
}
