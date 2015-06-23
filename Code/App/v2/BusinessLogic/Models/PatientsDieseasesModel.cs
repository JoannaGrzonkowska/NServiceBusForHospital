using System.Collections.Generic;

namespace BusinessLogic.Models
{
    public class PatientsDieseasesModel
    {
        public int Id { get; set; }
        public string DieseaseName { get; set; }
        public string Description { get; set; }
        public IEnumerable<ExaminationsModel> DieseasesExaminations { get; set; }
    }
}