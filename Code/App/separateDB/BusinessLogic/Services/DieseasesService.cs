using BusinessLogic.Models;
using DataAccess.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Services
{
    public class DieseasesService : IDieseasesService
    {
        private readonly IDieseasesRepository _dieseasesRepository;

        public DieseasesService(IDieseasesRepository dieseasesRepository)
        {
            _dieseasesRepository = dieseasesRepository;
        }

        public IEnumerable<DieseasesModel> GetAll()
        {
            return _dieseasesRepository
                .GetAll()
                .OrderBy(o=>o.Name)
                .Select(s => new DieseasesModel
                {
                    Id = s.Id,
                    Name = s.Name
                });
        }
    }
}
