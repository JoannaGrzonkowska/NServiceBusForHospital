using Messages.Common;
using Messages.Models;
using Messages.Ward;

namespace UsgBusinessLogic.Services
{
    public interface IExaminationsService
    {
       CommandResult Add(ExaminationMessage examinationMessage,
           LogTypeEnum.LogType logType,
           ref int examinationId);

    }
}
