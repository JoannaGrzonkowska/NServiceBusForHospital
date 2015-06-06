using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PatientAlergyRepository: RepositoryBase<PatientAlergies, HospitalTestEntities>, IPatientAlergyRepository
    {
        public PatientAlergyRepository(HospitalTestEntities context)
            : base(context)
        {

        }
        public IEnumerable<PatientAlergies> GetPatientAlergies(int patientId)
        {
            return Context.Set<PatientAlergies>()
                .Where(x => x.PatientId == patientId)
                .OrderByDescending(o => o.WhenDiagnosed);
        }
     }
}

