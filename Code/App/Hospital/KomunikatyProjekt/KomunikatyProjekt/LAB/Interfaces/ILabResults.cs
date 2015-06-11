using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomunikatyProjekt.Laboratorium.Interfejsy
{
    public interface ILabResults
    {
        int OrderID { get; set; }
        string Name { get; set; }
    }
}
