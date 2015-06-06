using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class AlergyRepository : RepositoryBase<Alergies, HospitalTestEntities>, IAlergyRepository
    {
        public AlergyRepository(HospitalTestEntities context)
            : base(context)
        {

        }
    }
}
