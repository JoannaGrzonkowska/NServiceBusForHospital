using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models.Commands
{
    public class AddAlergyToPatientCommand
    {
        public int AlergyId { get; set; }
        public int PatientId { get; set; }
        public string Description { get; set; }
    }
}
