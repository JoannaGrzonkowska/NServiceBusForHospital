using Messages.Common;
using Messages.Models;
using Messages.Ward;
using UsgDataAccess;
using UsgDataAccess.Repositories;

namespace UsgBusinessLogic.Services
{
    public class ExaminationsService : IExaminationsService
    {
        private readonly IExaminationsRepository _examinationsRepository;

        public ExaminationsService(IExaminationsRepository examinationsRepository)
        {
            _examinationsRepository = examinationsRepository;
        }

        public CommandResult Add(ExaminationMessage examinationMessage,
            LogTypeEnum.LogType logType,
            ref int examinationId)
        {
            var examination = new Examinations
            {
                ExtPatientDieseaseId = examinationMessage.ExtPatientDieseaseId,
                LogType = (int)logType,
                Comment = examinationMessage.Comment,
                WhenExamined = examinationMessage.When
            };
            return _examinationsRepository.Add(examination, ref examinationId);
        }
    }
}
