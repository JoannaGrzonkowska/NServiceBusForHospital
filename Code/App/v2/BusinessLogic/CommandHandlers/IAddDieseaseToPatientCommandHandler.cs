using BusinessLogic.Models.Commands;
using Messages.Common;

namespace BusinessLogic.CommandHandlers
{
    public interface IAddDieseaseToPatientCommandHandler
    {
        CommandResult Add(AddDieseaseToPatientCommand command);
    }
}
