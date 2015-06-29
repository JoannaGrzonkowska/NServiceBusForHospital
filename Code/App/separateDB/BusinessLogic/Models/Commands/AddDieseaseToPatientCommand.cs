
namespace BusinessLogic.Models.Commands
{
    public class AddDieseaseToPatientCommand
    {
    
        public int DieseaseId { get; set; }
        public int PatientId { get; set; }
        public string Description { get; set; }
    }
}

 
