using BusinessLogic.Models;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
    public interface IDieseasesService
    {
        IEnumerable<DieseasesModel> GetAll();
    }
}
