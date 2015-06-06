using BusinessLogic.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class AlergyService : IAlergyService
    {
        private readonly IAlergyRepository _alergyRepository;

        public AlergyService(IAlergyRepository alergyRepository)
        {
            _alergyRepository = alergyRepository;
        }

        public IEnumerable<AlergyTypeModel> GetAll()
        {
            return _alergyRepository
                .GetAll()
                .OrderBy(o=>o.Name)
                .Select(s => new AlergyTypeModel
                {
                    Id = s.Id,
                    Name = s.Name
                });
        }
    }
}
