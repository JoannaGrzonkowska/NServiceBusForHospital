using BusinessLogic.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
