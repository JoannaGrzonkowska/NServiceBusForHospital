
using BusinessLogic.Models;
using DataAccess;
using DataAccess.Repositories;
namespace BusinessLogic.Services
{
    public class PatientsService : IPatientsService
    {
        private readonly IPatientsRepository _patientsRepository;

        public PatientsService(IPatientsRepository patientRepository)
        {
            _patientsRepository = patientRepository;
        }

        public PatientsModel GetById(int id)
        {
            var patient = _patientsRepository.GetById(id);
            return new PatientsModel
            {
                Name = patient.Name,
                Age = patient.Age
            };
        }

        public Patients GetByName(string name)
        {
            return _patientsRepository.GetByName(name);
        }

        public PatientsModel GetModelByName(string name)
        {
            var patient = _patientsRepository.GetByName(name);
            return new PatientsModel
            {
                Id = patient.Id,
                Name = patient.Name
            };
        }
    }
}
