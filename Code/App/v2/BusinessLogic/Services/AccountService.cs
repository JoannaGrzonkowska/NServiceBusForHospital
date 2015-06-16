using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class AccountService : IAccountService
    {

        public bool IsValid(string name, string password)
        {
            throw new NotImplementedException();
        }

        public Messages.Common.CommandResult AddUser(string name, string password)
        {
            throw new NotImplementedException();
        }
    }
}