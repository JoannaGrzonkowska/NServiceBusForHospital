using Messages.Common;
using RepositoryClasses;
using System.Collections.Generic;

namespace WardDataAccess.Repositories
{
    public interface IExaminationsRepository : IRepository<Examinations>
    {
        IEnumerable<Examinations> GetExaminationsByPatientDieseaseId(int patientDieseaseId);
        CommandResult Add(Examinations examination, ref int examinationId);
    
    }
}
