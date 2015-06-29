using Messages.Common;
using RepositoryClasses;

namespace DataAccess.Repositories
{
    public interface IDirectorMessagesRepository : IRepository<DirectorMessages>
    {
        CommandResult Add(DirectorMessages directorMessage, ref int examinationId);
    }
}
