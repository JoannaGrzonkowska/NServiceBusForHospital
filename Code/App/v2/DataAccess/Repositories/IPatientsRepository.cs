using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IPatientsRepository : IRepository<Patients>
    {
        void Update(Patients patient);
        Patients GetByName(string name);
    }
}
