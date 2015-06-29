using Messages.Common;
using RepositoryClasses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using WardDataAccess;
using WardDataAccess.Repositories;

namespace WardBusinessLogic.Services
{
    public class DirectorMessagesService : IDirectorMessagesService
    {
        private readonly IDirectorMessagesRepository _directorMessagesRepository;

        public DirectorMessagesService(IDirectorMessagesRepository examinationsRepository)
        {
            _directorMessagesRepository = examinationsRepository;
        }

        public CommandResult Add(DirectorMessagesModel directorMessageModel, ref int directorMessageId)
        {
            var directorMessage = new DirectorMessages
            {
                Comment = directorMessageModel.Comment,
                When = directorMessageModel.When,
                ExtDirectorMessageId = directorMessageModel.Id
            };
            return _directorMessagesRepository.Add(directorMessage, ref directorMessageId);
        }

        public IEnumerable<DirectorMessagesModel> GetAll()
        {
            return _directorMessagesRepository.GetAll().OrderByDescending(o=>o.When).Select(x => new DirectorMessagesModel
            {
                Comment = x.Comment,
                When = x.When,
                Id = x.Id
            });
        }
    }
}
