using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
   public class PatientAlergyModel
    {
        public int AlergyId { get; set; }
        public string AlergyName { get; set; }
        public string Description { get; set; }
        public DateTime WhenDiagnosed { get; set; }
    }
}
