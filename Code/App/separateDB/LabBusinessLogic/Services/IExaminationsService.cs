using Messages.Common;
using Messages.Models;
using Messages.Ward;

namespace LabBusinessLogic.Services
{
    public interface IExaminationsService
    {
       CommandResult Add(ExaminationMessage examinationMessage,
           LogTypeEnum.LogType logType,
           ref int examinationId);

    }
}
