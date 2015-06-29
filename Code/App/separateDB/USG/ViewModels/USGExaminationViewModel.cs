using RepositoryClasses.Models;

namespace USG.ViewModels
{
    public class USGExaminationViewModel
    {
        public PatientsModel PatientInfo { get; set; }
        public USGExaminationCommentViewModel USGComment { get; set; }
        public int PatientDieseaseId { get; set; }
    }
}