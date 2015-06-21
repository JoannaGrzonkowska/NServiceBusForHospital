using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ward.ViewModels
{
    public class WardPatientCurrentDieseaseViewModel
    {
        public int PatientDieseaseId { get; set; }
        public string DieseaseDescription { get; set; }
        public string DieseaseName { get; set; }
    }
}