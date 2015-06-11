using Messages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IAccountService
    {
        bool IsValid(string name, string password);
        CommandResult AddUser(string name, string password);
    }
}
