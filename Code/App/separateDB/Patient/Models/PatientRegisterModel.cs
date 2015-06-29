using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Patient.Models
{
    public class PatientRegisterModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, MinimumLength = 3)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 3)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [DisplayName("Age")]
        public int Age { get; set; }
    }
}