using System.Collections.Generic;

namespace RepositoryClasses.Models
{
    public class PatientsDieseasesModel
    {
        public int Id { get; set; }
        public string DieseaseName { get; set; }
        public string Description { get; set; }
        public IEnumerable<ExaminationsModel> DieseasesExaminations { get; set; }
        public int ExtPatientDieseaseId { get; set; }
    }
}