using Messages.Common;
using RepositoryClasses.Models;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
    public interface IDirectorMessagesService
    {
        CommandResult Add(DirectorMessagesModel directorMessageModel, ref int directorMessageId);
        IEnumerable<DirectorMessagesModel> GetAll();
    }
}
