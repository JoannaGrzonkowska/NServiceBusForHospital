using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels
{
    public class PatientPersonalDataViewModel
    {
        public PatientInfoViewModel Info { get; set; }
        public IEnumerable<PatientAlergyViewModel> PatientAlergies { get; set; }
        public IEnumerable<AlergyTypeViewModel> AlergyTypes { get; set; }
        public PatientLocalizations PatientLocalizations { get; set; }
        public int AlergyDescriptionMaxLength { get; set; }
    }
}