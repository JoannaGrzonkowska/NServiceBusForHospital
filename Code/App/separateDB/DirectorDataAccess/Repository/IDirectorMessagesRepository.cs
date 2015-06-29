using Messages.Common;
using RepositoryClasses;

namespace DirectorDataAccess.Repositories
{
    public interface IDirectorMessagesRepository : IRepository<DirectorMessages>
    {
        CommandResult Add(DirectorMessages directorMessage, ref int examinationId);
    }
}
