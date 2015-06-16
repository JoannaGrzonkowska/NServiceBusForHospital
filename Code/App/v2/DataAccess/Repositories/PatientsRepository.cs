using System.Data;
using System.Linq;

namespace DataAccess.Repositories
{
    public class PatientsRepository : RepositoryBase<Patients, HospitalKSREntities>, IPatientsRepository
    {
        public PatientsRepository(HospitalKSREntities context)
            : base(context)
        {

        }
        
        public void Update(Patients patient)
        {
            Context.Patients.Attach(patient);
            Context.Entry(patient).State = EntityState.Modified;
        }

        public Patients GetByName(string name)
        {
            return Context.Set<Patients>()
                .Where(x => x.Name.Equals(name)).FirstOrDefault();
        }
    }
}
