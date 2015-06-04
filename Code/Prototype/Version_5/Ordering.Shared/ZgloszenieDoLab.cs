using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Shared
{
    public class ZgloszenieDoLab : ICommand
    {
       public int IdPacjenta { get; set; }
       public int IdBadania { get; set; }
    }
}
