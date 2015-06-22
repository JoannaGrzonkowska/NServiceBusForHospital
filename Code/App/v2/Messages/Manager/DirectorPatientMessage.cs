
namespace Messages
{
    public class DirectorPatientMessage : IDirectorPatientMessage
    {
        public int MessageId { get; set; }
        public string Content { get; set; }
    }
}
