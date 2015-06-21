using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blood.ViewModels
{
    public class BloodExaminationViewModel
    {
        public PatientsModel PatientInfo { get; set; }
        public BloodExaminationCommentViewModel BloodComment { get; set; }
        public int PatientDieseaseId { get; set; }
    }
}