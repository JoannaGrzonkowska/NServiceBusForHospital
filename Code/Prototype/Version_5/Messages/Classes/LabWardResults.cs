﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages.Interfaces;

namespace Messages.Classes
{
    class LabWardResults :ILabWardResults
    {
        public int PatientId { get; set; }

        public string Comment { get; set; }
    }
}
