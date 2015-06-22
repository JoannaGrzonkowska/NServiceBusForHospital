using System;

namespace KomunikatyProjekt.IzbaPrzyjec
{
    public interface IWardAcceptance
    {
        int PatientID { get; set; }
        DateTime IssueDate { get; set; }
       // string Uwagi { get; set; }
    }
}
