using BusinessLogic.CommandHandlers;
using BusinessLogic.Models.Commands;
using Ordering.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class AccountService : IAccountService
    {
        private readonly IPatientService _patientService;
        private readonly IAddPatientCommandHandler _addPatientCommandHandler;

        public AccountService(IPatientService patientService,
            IAddPatientCommandHandler addPatientCommandHandler)
        {
            _patientService = patientService;
            _addPatientCommandHandler = addPatientCommandHandler;
        }

        public bool IsValid(string name, string password)
        {
            var user = _patientService.GetByName(name);
            if (user == null)
            {
                return false;
            }
            var simpleCrypto = new SimpleCrypto.PBKDF2();

            if (user.Password == simpleCrypto.Compute(password, user.PasswordSalt))
            {
                return true;
            }
            return false;

        }

        public CommandResult AddUser(string name, string password)
        {
            var simpleCrypto = new SimpleCrypto.PBKDF2();
            var encryptedPassword = simpleCrypto.Compute(password);

           return _addPatientCommandHandler.Add(new AddPatientCommand
            {
                Name = name,
                Password = encryptedPassword,
                PasswordSalt = simpleCrypto.Salt
            });
        }
    }
}
