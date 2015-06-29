using RepositoryClasses.Models;

namespace Blood.ViewModels
{
    public class BloodExaminationViewModel
    {
        public PatientsModel PatientInfo { get; set; }
        public BloodExaminationCommentViewModel BloodComment { get; set; }
        public int PatientDieseaseId { get; set; }
    }
}