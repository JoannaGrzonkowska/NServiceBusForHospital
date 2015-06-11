using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomunikatyProjekt.Skierowania
{
    public interface IReferral
    {
        int TreatmentID { get; set; }
        int PatientID { get; set; }
        int IssuedDoctorID { get; set; }
        DateTime IssueDate { get; set; }


        

    }
}
