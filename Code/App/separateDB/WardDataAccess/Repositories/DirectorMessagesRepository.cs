using Messages.Common;
using RepositoryClasses;

namespace WardDataAccess.Repositories
{
    public class DirectorMessagesRepository : RepositoryBase<DirectorMessages, KSR_WardEntities>, IDirectorMessagesRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public DirectorMessagesRepository(KSR_WardEntities context,
            IUnitOfWork unitOfWork)
            : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public CommandResult Add(DirectorMessages directorMessage, ref int directorMessageId)
        {
            Add(directorMessage);
            _unitOfWork.SaveChanges();

            directorMessageId = directorMessage.Id;

            return new CommandResult();
        }
    }
}
