using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Messages
{
    public class ExaminationTypeEnum
    {
        public enum ExaminationType
        {
            BLOOD = 1,
            RTG = 2,
            USG = 3,
            LAB = 4
        }
        public static string GetName(ExaminationType type)
        {
            switch (type)
            {
                case ExaminationType.BLOOD: return "Blood";
                case ExaminationType.RTG: return "RTG";
                case ExaminationType.USG: return "USG";
                case ExaminationType.LAB: return "Lab";
                default: return string.Empty;
            }
        }
    }
}