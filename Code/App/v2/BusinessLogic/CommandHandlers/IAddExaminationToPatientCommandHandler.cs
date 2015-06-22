using BusinessLogic.Models.Commands;
using Messages.Common;

namespace BusinessLogic.CommandHandlers
{
    public interface IAddExaminationToPatientCommandHandler
    {
        CommandResult Add(AddExaminationToPatientCommand command, ref int examinationId);
    }
}
