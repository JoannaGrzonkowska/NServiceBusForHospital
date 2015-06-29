using Messages;
using Messages.Common;
using RepositoryClasses.Models;
using WardDataAccess;
using WardDataAccess.Repositories;

namespace WardBusinessLogic.Services
{
    public class PatientsDieseasesService : IPatientsDieseasesService
    {
        private readonly IPatientsDieseasesRepository _patientsDieseasesRepository;

        public PatientsDieseasesService(IPatientsDieseasesRepository patientsDieseasesRepository)
        {
            _patientsDieseasesRepository = patientsDieseasesRepository;
        }

        public CommandResult Add(PatientDieseaseMessage patientDiesease, int patientId, ref int patientDieseaseId)
        {
            var patientDieseaseEntity = new PatientsDieseases
            {
                PatientId = patientId,
                Description = patientDiesease.Description,
                ExtPatientDieseaseId = patientDiesease.PatientDieseaseId
            };
            return _patientsDieseasesRepository.Add(patientDieseaseEntity, ref patientDieseaseId);
        }

        public PatientsDieseasesModel GetByExtPatientDieseaseId(int extPatientDieseaseId)
        {
            var patientDiesease = _patientsDieseasesRepository.GetByExtPatientDieseaseId(extPatientDieseaseId);
            return new PatientsDieseasesModel
            {
                Id = patientDiesease.Id,
                ExtPatientDieseaseId = patientDiesease.ExtPatientDieseaseId
            };
        }
    }
}
