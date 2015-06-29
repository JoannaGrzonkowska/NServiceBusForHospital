using BusinessLogic.Models;
using DataAccess;
using RepositoryClasses.Models;

namespace BusinessLogic.Services
{
    public interface IPatientsService
    {
        PatientsModel GetById(int id);
        Patients GetByName(string name);
        PatientsModel GetModelByName(string name);
    }
}
