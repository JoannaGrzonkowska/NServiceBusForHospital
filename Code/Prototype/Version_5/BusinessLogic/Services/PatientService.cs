using BusinessLogic.Models;
using DataAccess;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public IEnumerable<PatientModel> TestMethod1_1(int id)
        {
            var patients = _patientRepository.TestMethod1(id);
            return patients.Select(x => new PatientModel
            {
                Name = x.Name
            }).ToList();
        }
    }
}
