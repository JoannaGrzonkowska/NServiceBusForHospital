using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RTG.ViewModels
{
    public class RTGExaminationViewModel
    {
        public PatientsModel PatientInfo { get; set; }
        public RTGExaminationCommentViewModel RTGComment { get; set; }

    }
}