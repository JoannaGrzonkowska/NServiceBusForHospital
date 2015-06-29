using Messages.Common;
using RepositoryClasses.Models;

namespace BusinessLogic.CommandHandlers
{
    public interface IAddExaminationToPatientCommandHandler
    {
        CommandResult Add(ExaminationsModel command, ref int examinationId);
    }
}
