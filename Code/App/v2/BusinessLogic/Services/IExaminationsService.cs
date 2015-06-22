using BusinessLogic.Models;

namespace BusinessLogic.Services
{
    public interface IExaminationsService
    {
        ExaminationsModel GetById(int id);
    }
}
