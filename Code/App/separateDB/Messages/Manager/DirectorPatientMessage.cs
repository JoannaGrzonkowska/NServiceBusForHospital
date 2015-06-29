using System;

namespace Messages
{
    public class DirectorPatientMessage : IDirectorPatientMessage
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime When { get; set; }
    }
}
