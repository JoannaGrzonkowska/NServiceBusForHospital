using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Shared
{
    public class WynikiDlaPacjenta:ICommand
    {
        public int Wynik { get; set; }
    }
}
