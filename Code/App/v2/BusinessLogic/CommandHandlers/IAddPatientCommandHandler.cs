using BusinessLogic.Models.Commands;
using Messages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.CommandHandlers
{
    public interface IAddPatientCommandHandler
    {
        CommandResult Add(AddPatientCommand command);
    }
}
