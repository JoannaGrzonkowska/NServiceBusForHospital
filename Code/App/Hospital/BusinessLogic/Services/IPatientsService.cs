using BusinessLogic.Models;
using DataAccess;

namespace BusinessLogic.Services
{
    public interface IPatientsService
    {
        PatientsModel GetById(int id);
        Patients GetByName(string name);
        PatientsModel GetModelByName(string name);
    }
}
