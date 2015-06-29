using RepositoryClasses.Models;

namespace RTG.ViewModels
{
    public class RTGExaminationViewModel
    {
        public PatientsModel PatientInfo { get; set; }
        public RTGExaminationCommentViewModel RTGComment { get; set; }
        public int PatientDieseaseId { get; set; }
    }
}