using Messages.Common;

namespace BusinessLogic.Services
{
    public interface IAccountService
    {
        bool IsValid(string name, string password);
        CommandResult AddUser(string name, string password, int age);
    }
}
