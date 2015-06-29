using DataAccess.Repositories;
using Messages;
using Messages.Models;
using RepositoryClasses.Models;
using System.Collections.Generic;
using System.Linq;

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
            var patientDieseasesAndExaminations = _patientsDieseasesRepository.GetPatientsDieseases(patientId);
            List<PatientsDieseasesModel> result = new List<PatientsDieseasesModel>();

            patientDieseasesAndExaminations.ToList().ForEach(x => {
                IEnumerable<ExaminationsModel> examinations = x.Examinations.Select(t => new ExaminationsModel 
                    {
                        Comment = t.Comment,
                        ExaminationType = (ExaminationTypeEnum.ExaminationType)t.ExaminationType,
                        Id = t.Id,
                        LogType = (LogTypeEnum.LogType)t.LogType,
                        PatientDieseaseId = t.PatientDieseaseId,
                        When = t.WhenExamined
                    });
                result.Add(new PatientsDieseasesModel
                {
                    Id = x.Id,
                    DieseaseName = x.Dieseases.Name,
                    Description = x.Description,
                    DieseasesExaminations = examinations
                });
            });


            return result;
        }

        public PatientsModel GetPatientById(int id)
        {
            var patient = _patientsDieseasesRepository.GetById(id).Patients;
            return new PatientsModel
            {
                Name = patient.Name,
                Age = patient.Age,
                Id = patient.Id
            };
        }
    }
}
