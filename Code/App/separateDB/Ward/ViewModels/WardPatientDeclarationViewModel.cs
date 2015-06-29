using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepositoryClasses.Models;

namespace Ward.ViewModels
{
    public class WardPatientDeclarationViewModel
    {
        public PatientsModel PatientInfo { get; set; }
        public WardPatientCurrentDieseaseViewModel CurrentDiesease { get; set; }
    }

}