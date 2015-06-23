using BusinessLogic.Models;
using DataAccess;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
    public interface IExaminationsService
    {
        ExaminationsModel GetById(int id);
        List<ExaminationsModel> GetExaminationsByPatientDieseaseIdWithFilter(int patientDieseaseId, int logType);

    }
}
