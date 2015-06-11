using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomunikatyProjekt.IzbaPrzyjec
{
    public interface IWardAcceptance
    {
        int PatientID { get; set; }
        DateTime IssueDate { get; set; }
       // string Uwagi { get; set; }
    }
}
