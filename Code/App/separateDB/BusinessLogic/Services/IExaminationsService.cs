using RepositoryClasses.Models;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
    public interface IExaminationsService
    {
        ExaminationsModel GetById(int id);
        List<ExaminationsModel> GetExaminationsByPatientDieseaseIdWithFilter(int patientDieseaseId);

    }
}
