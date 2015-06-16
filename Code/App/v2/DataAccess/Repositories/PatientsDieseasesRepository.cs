using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PatientsDieseasesRepository: RepositoryBase<PatientsDieseases, HospitalKSREntities>, IPatientsDieseasesRepository
    {
        public PatientsDieseasesRepository(HospitalKSREntities context)
            : base(context)
        {

        }
        public IEnumerable<PatientsDieseases> GetPatientsDieseases(int patientId)
        {
            return Context.Set<PatientsDieseases>()
                .Where(x => x.PatientId == patientId);
        }
     }
}
