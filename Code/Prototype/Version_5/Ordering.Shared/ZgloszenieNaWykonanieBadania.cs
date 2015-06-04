using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Shared
{
    public class ZgloszenieNaWykonanieBadania:ICommand
    {
        public int IdTypuBadania { get; set; }
        public int IdPacjenta { get; set; }
   
    }
}
