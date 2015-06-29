using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Patient.Models
{
    public class PatientLoginModel
    {
        [Required(ErrorMessage = "Name is required")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}