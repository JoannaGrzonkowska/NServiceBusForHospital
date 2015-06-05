using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
     public class PatientRepository : RepositoryBase<Patient, HospitalTestEntities>, IPatientRepository
    {
        public PatientRepository(HospitalTestEntities context)
            : base(context)
        {

        }
        public IEnumerable<Patient> TestMethod1(int id)
        {
            return Context.Set<Patient>()
                .Where(x => x.Id >1);

        }
     }
}
