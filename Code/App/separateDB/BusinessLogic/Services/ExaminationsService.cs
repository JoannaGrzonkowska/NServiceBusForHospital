using BusinessLogic.Models;
using DataAccess;
using DataAccess.Repositories;
using Messages;
using RepositoryClasses.Models;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
    public class ExaminationsService : IExaminationsService
    {
        private readonly IExaminationsRepository _examinationsRepository;

        public ExaminationsService(IExaminationsRepository examinationsRepository)
        {
            _examinationsRepository = examinationsRepository;
        }

        public ExaminationsModel GetById(int id)
        {
            var examination = _examinationsRepository.GetById(id);
            return new ExaminationsModel
            {
                Id = examination.Id,
                PatientDieseaseId = examination.PatientDieseaseId,
                ExaminationType = (ExaminationTypeEnum.ExaminationType)examination.ExaminationType,
                LogType = (Messages.Models.LogTypeEnum.LogType)examination.LogType,
                Comment = examination.Comment,
                When = examination.WhenExamined
            };
        }



        public List<ExaminationsModel> GetExaminationsByPatientDieseaseIdWithFilter(int patientDieseaseId)
        {
            var examinations = _examinationsRepository.GetExaminationsByPatientDieseaseIdWithFilter(patientDieseaseId);
            List<ExaminationsModel> examinationModelsList = new List<ExaminationsModel>();
            foreach(var examination in examinations)
            {
                examinationModelsList.Add(new ExaminationsModel
                {
                    Id = examination.Id,
                    ExaminationType = (Messages.ExaminationTypeEnum.ExaminationType)examination.ExaminationType,
                    PatientDieseaseId = examination.PatientDieseaseId,
                    LogType = (Messages.Models.LogTypeEnum.LogType)examination.LogType,
                    Comment = examination.Comment,
                    When = examination.WhenExamined

                });
            }
            return examinationModelsList;
        }
    }
}
