using BusinessLogic.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class PatientsDieseasesService : IPatientsDieseasesService
    {
        private readonly IPatientsDieseasesRepository _patientsDieseasesRepository;

        public PatientsDieseasesService(IPatientsDieseasesRepository patientsDieseasesRepository)
        {
            _patientsDieseasesRepository = patientsDieseasesRepository;
        }

        public IEnumerable<PatientsDieseasesModel> GetPatientsDieseases(int patientId)
        {
            return _patientsDieseasesRepository.GetPatientsDieseases(patientId)
                .Select(s => new PatientsDieseasesModel
                {
                    PatientId = s.PatientId,
                    DieseaseName = s.Dieseases.Name,
                    Description = s.Description,
                });
        }
    }
}
