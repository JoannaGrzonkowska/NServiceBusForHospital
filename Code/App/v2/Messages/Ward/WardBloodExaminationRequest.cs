﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class WardBloodExaminationRequest : IWardBloodExaminationRequest
    {
        public int PatientDieseaseId { get; set; }
        public int ExaminationId { get; set; }
    }
}
