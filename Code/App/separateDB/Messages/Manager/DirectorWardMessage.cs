
using System;
namespace Messages
{
    public class DirectorWardMessage : IDirectorWardMessage
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime When { get; set; }
    }
}
