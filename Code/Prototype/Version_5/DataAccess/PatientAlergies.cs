//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class PatientAlergies
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int AlergyId { get; set; }
        public string Description { get; set; }
        public System.DateTime WhenDiagnosed { get; set; }
    
        public virtual Alergies Alergies { get; set; }
        public virtual Patient Patient { get; set; }
    }
}