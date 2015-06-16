using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IPatientsDieseasesService
    {
        IEnumerable<PatientsDieseasesModel> GetPatientsDieseases(int patientId);
    }
}
