using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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