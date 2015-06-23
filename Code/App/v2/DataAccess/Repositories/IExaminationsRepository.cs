using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IExaminationsRepository : IRepository<Examinations>
    {
        IEnumerable<Examinations> GetExaminationsByPatientDieseaseId(int patientDieseaseId);
        IEnumerable<Examinations> GetExaminationsByPatientDieseaseIdWithFilter(int patientDieseaseId, int logType);
    
    }
}
