using Messages;

namespace BusinessLogic.Models
{
    public class Examination
    {
        public ExaminationTypeEnum.ExaminationType Type { get; set; }
        public bool IsReceived { get; set; }
        public Examination(ExaminationTypeEnum.ExaminationType type)
        {
            Type = type;
            IsReceived = false;
        }

    }
}
