using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace USG.ViewModels
{
    public class USGExaminationViewModel
    {
        public PatientsModel PatientInfo { get; set; }
        public USGExaminationCommentViewModel USGComment { get; set; }

    }
}