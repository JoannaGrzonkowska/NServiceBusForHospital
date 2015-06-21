using System.Collections.Generic;

namespace BusinessLogic.Models
{
    public class PatientsDieseasesModel
    {
        public string DieseaseName { get; set; }
        public string Description { get; set; }
        public IEnumerable<ExaminationsModel> DieseasesExaminations { get; set; }
    }
}