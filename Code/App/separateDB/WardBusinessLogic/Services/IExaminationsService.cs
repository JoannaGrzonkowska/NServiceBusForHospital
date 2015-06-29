using Messages;
using Messages.Common;
using Messages.Models;
using Messages.Ward;
using RepositoryClasses.Models;
using System.Collections.Generic;

namespace WardBusinessLogic.Services
{
    public interface IExaminationsService
    {
       List<ExaminationsModel> GetExaminationsByPatientDieseaseId(int patientDieseaseId);

       CommandResult Add(ExaminationMessage examinationMessage,
           ExaminationTypeEnum.ExaminationType examinationType,
           LogTypeEnum.LogType logType,
           ref int examinationId);

    }
}
