using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages.Interfaces;

namespace Messages.Classes
{
    class WardUSGExamination : IWardUSGExamination
    {
        public int PatientId { get; set; }
    }
}
