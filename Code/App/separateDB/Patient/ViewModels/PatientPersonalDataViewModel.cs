using BusinessLogic.Models;
using RepositoryClasses.Models;
using System.Collections.Generic;

namespace Patient.ViewModels
{
    public class PatientPersonalDataViewModel
    {
        public PatientsModel Info { get; set; }
        public IEnumerable<PatientsDieseasesModel> PatientDieseases { get; set; }
        public IEnumerable<DieseasesModel> DieseasesTypes { get; set; }
        public int DieseaseDescriptionMaxLength { get; set; }
    }
}