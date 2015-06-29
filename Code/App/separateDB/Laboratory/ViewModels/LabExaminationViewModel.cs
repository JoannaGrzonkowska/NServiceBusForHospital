using Laboratory.ViewModels;
using RepositoryClasses.Models;

namespace Laboratory.ViewModels
{
    public class LabExaminationViewModel
    {
        public PatientsModel PatientInfo { get; set; }
        public LabExaminationCommentViewModel LabComment { get; set; }
        public int PatientDieseaseId { get; set; }
    }
}