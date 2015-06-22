using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    //Class used to aquire data from page to controller (from sending message in Saga and data to DB)
    public class BloodRequestData
    {
        public string Comment { get; set; }
        public int PatientDieseaseId { get; set; }
    }
}
