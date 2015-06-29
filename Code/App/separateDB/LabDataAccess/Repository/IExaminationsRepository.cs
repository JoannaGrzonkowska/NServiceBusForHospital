using Messages.Common;
using RepositoryClasses;

namespace LabDataAccess.Repositories
{
    public interface IExaminationsRepository : IRepository<Examinations>
    {
        CommandResult Add(Examinations examination, ref int examinationId);
    }
}
