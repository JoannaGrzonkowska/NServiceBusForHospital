using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PatientRepository : RepositoryBase<Patient, HospitalKSREntities>, IPatientRepository
    {
        public PatientRepository(HospitalKSREntities context)
            : base(context)
        {

        }
        public IEnumerable<Patient> TestMethod1(int id)
        {
            return Context.Set<Patient>()
                .Where(x => x.Id >1);
        }

        public void Update(Patient patient)
        {
            Context.Patient.Attach(patient);
            Context.Entry(patient).State = EntityState.Modified;
        }

        public Patient GetByName(string name)
        {
            return Context.Set<Patient>()
                .Where(x => x.Name.Equals(name)).FirstOrDefault();
        }
     }
}
