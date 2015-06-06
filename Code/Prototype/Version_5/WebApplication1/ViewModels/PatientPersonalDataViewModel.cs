using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels
{
    public class PatientPersonalDataViewModel
    {
        public PatientModel Info { get; set; }
        public IEnumerable<PatientAlergyModel> PatientAlergies { get; set; }
        public IEnumerable<AlergyTypeModel> AlergyTypes { get; set; }
        public PatientLocalizations PatientLocalizations { get; set; }
        public int AlergyDescriptionMaxLength { get; set; }
    }
}