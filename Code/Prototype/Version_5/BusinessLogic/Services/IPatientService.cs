using BusinessLogic.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IPatientService
    {
        IEnumerable<PatientModel> TestMethod1_1(int id);
        PatientModel GetById(int id);
        Patient GetByName(string name);
        PatientModel GetModelByName(string name);
    }
}
