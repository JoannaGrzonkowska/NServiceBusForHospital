using Messages.Common;
using RepositoryClasses;

namespace RtgDataAccess.Repositories
{
    public interface IExaminationsRepository : IRepository<Examinations>
    {
        CommandResult Add(Examinations examination, ref int examinationId);
    }
}
