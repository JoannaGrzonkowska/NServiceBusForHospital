using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, MinimumLength=10)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 10)]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}