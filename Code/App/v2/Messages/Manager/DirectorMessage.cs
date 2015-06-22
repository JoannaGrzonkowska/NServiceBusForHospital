
namespace Messages
{
    public class DirectorMessage : IDirectorMessage
    {
        public int MessageId { get; set; }

        public string Content { get; set; }

        public int Type { get; set; }
    }
}
