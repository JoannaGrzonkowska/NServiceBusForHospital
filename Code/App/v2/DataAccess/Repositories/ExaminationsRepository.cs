using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ExaminationsRepository : RepositoryBase<Examinations, HospitalKSREntities>, IExaminationsRepository
    {
        public ExaminationsRepository(HospitalKSREntities context)
            : base(context)
        {
            

        }
        public IEnumerable<Examinations> GetExaminationsByPatientDieseaseId(int patientDieseaseId)
        {
            return Context.Set<Examinations>()
                .Where(x => x.PatientDieseaseId == patientDieseaseId);
        }
    }
}
