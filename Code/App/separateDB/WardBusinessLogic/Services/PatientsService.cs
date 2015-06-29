using Messages.Common;
using Messages.Ward;
using WardDataAccess;
using WardDataAccess.Repositories;
namespace WardBusinessLogic.Services
{
    public class PatientsService : IPatientsService
    {
        private readonly IPatientsRepository _patientsRepository;

        public PatientsService(IPatientsRepository patientRepository)
        {
            _patientsRepository = patientRepository;
        }

        public CommandResult AddIfNotExist(PatientMessage patientMessage, ref int patientId)
        {
            var patient = _patientsRepository.GetByExtPatientId(patientMessage.PatientId);
            if (patient == null)
            {
                _patientsRepository.Add(new Patients
                {
                    Name = patientMessage.Name,
                    Age = patientMessage.Age,
                    ExtPatientId = patientMessage.PatientId
                }, ref patientId);
            }
            else
            {
                patientId = patient.Id;
            }

            return new CommandResult();
        }
    }
}
