using Messages.Common;
using RepositoryClasses.Models;
using System.Collections.Generic;

namespace WardBusinessLogic.Services
{
    public interface IDirectorMessagesService
    {
        CommandResult Add(DirectorMessagesModel directorMessageModel, ref int directorMessageId);
        IEnumerable<DirectorMessagesModel> GetAll();
    }
}
