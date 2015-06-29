using Messages.Common;
using RepositoryClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardDataAccess.Repositories
{
    public interface IPatientsRepository : IRepository<Patients>
    {
        Patients GetByExtPatientId(int extPatientId);
        CommandResult Add(Patients patient, ref int patientId);
    }
}
