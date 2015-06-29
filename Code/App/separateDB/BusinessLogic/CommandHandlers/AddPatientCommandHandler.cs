using BusinessLogic.Models.Commands;
using DataAccess;
using DataAccess.Repositories;
using Messages.Common;

namespace BusinessLogic.CommandHandlers
{
    public class AddPatientCommandHandler : IAddPatientCommandHandler
    {
        private readonly IPatientsRepository _patientsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddPatientCommandHandler(
            IPatientsRepository patientsRepository,
            IUnitOfWork unitOfWork)
        {
            _patientsRepository = patientsRepository;
            _unitOfWork = unitOfWork;
        }

        public CommandResult Add(AddPatientCommand command)
        {
            var patient = new Patients
            {
                Name = command.Name,
                Password = command.Password,
                PasswordSalt = command.PasswordSalt,
                Age = command.Age
            };
            _patientsRepository.Add(patient);
            _unitOfWork.SaveChanges();

            return new CommandResult();
        }
    }
}
