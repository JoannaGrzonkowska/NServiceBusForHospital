using BusinessLogic.Models;
using DataAccess.Repositories;
using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ExaminationsService:IExaminationsService
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
    }
}
