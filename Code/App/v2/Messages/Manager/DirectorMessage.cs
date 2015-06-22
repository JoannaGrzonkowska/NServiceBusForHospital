
namespace Messages
{
    public class DirectorMessage : IDirectorMessage
    {
        public string Content { get; set; }
        public int Type { get; set; }
    }
}
