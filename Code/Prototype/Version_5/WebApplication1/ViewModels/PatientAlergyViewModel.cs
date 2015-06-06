using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels
{
    public class PatientAlergyViewModel
    {
        public int AlergyId { get; set; }
        public string AlergyName { get; set; }
        public string Description { get; set; }
        public DateTime WhenDiagnosed { get; set; }
    }
}