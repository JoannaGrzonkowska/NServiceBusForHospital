using Messages.Common;
using RepositoryClasses;

namespace DataAccess.Repositories
{
    public class DirectorMessagesRepository : RepositoryBase<DirectorMessages, HospitalKSREntities>, IDirectorMessagesRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public DirectorMessagesRepository(HospitalKSREntities context,
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
