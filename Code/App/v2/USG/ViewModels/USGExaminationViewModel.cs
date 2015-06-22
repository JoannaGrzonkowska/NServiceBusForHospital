using BusinessLogic.Models;

namespace USG.ViewModels
{
    public class USGExaminationViewModel
    {
        public PatientsModel PatientInfo { get; set; }
        public USGExaminationCommentViewModel USGComment { get; set; }

    }
}