using BusinessLogic.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class PatientAlergyService : IPatientAlergyService
    {
        private readonly IPatientAlergyRepository _patientAlergyRepository;

        public PatientAlergyService(IPatientAlergyRepository patientAlergyRepository)
        {
            _patientAlergyRepository = patientAlergyRepository;
        }

        public IEnumerable<PatientAlergyModel> GetPatientAlergies(int patientId)
        {
            return _patientAlergyRepository.GetPatientAlergies(patientId)
                .Select(s => new PatientAlergyModel
                {
                    AlergyId = s.AlergyId,
                    AlergyName = s.Alergies.Name,
                    Description = s.Description,
                    WhenDiagnosed = s.WhenDiagnosed
                });
        }
    }
}
