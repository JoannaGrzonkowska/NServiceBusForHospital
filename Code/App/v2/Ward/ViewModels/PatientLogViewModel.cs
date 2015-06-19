using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ward.ViewModels
{
    public class PatientLogViewModel
    {
        public int PatientId { get; set; }
        public string ExaminationName { get; set; }
        public string Comment { get; set; }
    }
}