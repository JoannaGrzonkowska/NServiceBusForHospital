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
    
    public partial class Alergies
    {
        public Alergies()
        {
            this.PatientAlergies = new HashSet<PatientAlergies>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<PatientAlergies> PatientAlergies { get; set; }
    }
}
