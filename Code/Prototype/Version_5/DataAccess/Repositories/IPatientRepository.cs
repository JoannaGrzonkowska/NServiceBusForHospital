using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IPatientRepository : IRepository<Patient>
    {
        IEnumerable<Patient> TestMethod1(int id);
        void Update(Patient patient);
        Patient GetByName(string name);
    }
}
