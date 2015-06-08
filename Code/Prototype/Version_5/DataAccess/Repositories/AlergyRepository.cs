using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class AlergyRepository : RepositoryBase<Alergies, HospitalKSREntities>, IAlergyRepository
    {
        public AlergyRepository(HospitalKSREntities context)
            : base(context)
        {

        }
    }
}
