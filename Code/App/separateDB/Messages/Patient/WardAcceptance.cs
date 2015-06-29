using Messages.Ward;

namespace Messages
{
    public class WardAcceptance:IWardAcceptance
    {
        public PatientMessage Patient{ get; set; }
        public PatientDieseaseMessage Diesease { get; set; }
    }
}
