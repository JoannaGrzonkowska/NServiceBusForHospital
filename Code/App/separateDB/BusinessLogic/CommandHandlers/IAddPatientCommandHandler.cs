using BusinessLogic.Models.Commands;
using Messages.Common;

namespace BusinessLogic.CommandHandlers
{
    public interface IAddPatientCommandHandler
    {
        CommandResult Add(AddPatientCommand command);
    }
}
