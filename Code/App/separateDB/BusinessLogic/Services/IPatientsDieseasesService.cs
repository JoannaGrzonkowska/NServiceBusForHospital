using RepositoryClasses.Models;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
    public interface IPatientsDieseasesService
    {
        IEnumerable<PatientsDieseasesModel> GetPatientsDieseases(int patientId);
        PatientsModel GetPatientById(int id);
    }
}
