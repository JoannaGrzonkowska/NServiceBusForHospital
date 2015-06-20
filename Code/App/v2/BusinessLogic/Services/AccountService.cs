using BusinessLogic.CommandHandlers;
using BusinessLogic.Models.Commands;
using Messages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class AccountService : IAccountService
    {
        private readonly IPatientsService _patientService;
        private readonly IAddPatientCommandHandler _addPatientCommandHandler;

        public AccountService(IPatientsService patientService,
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

            try
            {
                if (user.Password == simpleCrypto.Compute(password, user.PasswordSalt))
                {
                    return true;
                }
            }
            catch (Exception e) { return true; }

            return false;

        }

        public CommandResult AddUser(string name, string password, int age)
        {
            var simpleCrypto = new SimpleCrypto.PBKDF2();
            var encryptedPassword = simpleCrypto.Compute(password);

            return _addPatientCommandHandler.Add(new AddPatientCommand
            {
                Name = name,
                Password = encryptedPassword,
                PasswordSalt = simpleCrypto.Salt,
                Age = age
            });
        }

        public Messages.Common.CommandResult AddUser(string name, string password)
        {
            throw new NotImplementedException();
        }
    }
}