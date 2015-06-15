using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ward.Models
{
    public class Examination
    {
        public ExaminationType Type { get; set; }
        public bool IsReceived { get; set; }
        public Examination(ExaminationType type)
        {
            Type = type;
            IsReceived = false;
        }
        
    }
}