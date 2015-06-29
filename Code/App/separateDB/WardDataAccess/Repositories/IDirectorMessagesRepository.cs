using Messages.Common;
using RepositoryClasses;

namespace WardDataAccess.Repositories
{
    public interface IDirectorMessagesRepository : IRepository<DirectorMessages>
    {
        CommandResult Add(DirectorMessages directorMessage, ref int examinationId);
    }
}
