using Messages;
using Messages.Common;
using Messages.Models;
using Messages.Ward;
using RepositoryClasses.Models;
using System.Collections.Generic;
using WardDataAccess;
using WardDataAccess.Repositories;

namespace WardBusinessLogic.Services
{
    public class ExaminationsService : IExaminationsService
    {
        private readonly IExaminationsRepository _examinationsRepository;
        private readonly IPatientsDieseasesService _patientsDieseasesService;
        
        public ExaminationsService(IExaminationsRepository examinationsRepository,
            IPatientsDieseasesService patientsDieseasesService)
        {
            _examinationsRepository = examinationsRepository;
            _patientsDieseasesService = patientsDieseasesService;
        }

        public List<ExaminationsModel> GetExaminationsByPatientDieseaseId(int patientDieseaseId)
        {
            var examinations = _examinationsRepository.GetExaminationsByPatientDieseaseId(patientDieseaseId);
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

        public CommandResult Add(ExaminationMessage examinationMessage, 
            ExaminationTypeEnum.ExaminationType examinationType,
            LogTypeEnum.LogType logType,
            ref int examinationId)
        {
            var patientDieseaseId = _patientsDieseasesService.GetByExtPatientDieseaseId(examinationMessage.ExtPatientDieseaseId).Id;

            var examination = new Examinations
            {
                PatientDieseaseId = patientDieseaseId,
                ExaminationType = (int)examinationType,
                LogType = (int)logType,
                Comment = examinationMessage.Comment,
                WhenExamined = examinationMessage.When
            };
            return _examinationsRepository.Add(examination, ref examinationId);
        }
    }
}
