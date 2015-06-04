using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Shared
{
    public class WynikiZLaboratorium : ICommand
    {
        public int IdPacjenta { get; set; }
        public int Wynik { get; set; }
        public string Opis { get; set; }
    }
}
