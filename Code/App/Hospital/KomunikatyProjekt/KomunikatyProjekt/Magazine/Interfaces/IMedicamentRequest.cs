using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomunikatyProjekt.Magazyn
{
    public interface IMedicamentRequest
    {
        List<Medicament> Order { get; set; }
        int WardID { get; set; } 
        
    }
}
