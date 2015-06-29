﻿
namespace BusinessLogic.Models.Commands
{
    public class AddPatientCommand
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public int Age { get; set; }
    }
}
