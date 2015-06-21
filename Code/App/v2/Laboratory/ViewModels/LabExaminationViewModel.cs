using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratory.ViewModels
{
    public class LabExaminationViewModel
    {
        public PatientsModel PatientInfo { get; set; }
        public LabExaminationCommentViewModel LabComment { get; set; }
        public int PatientDieseaseId { get; set; }
    }
}