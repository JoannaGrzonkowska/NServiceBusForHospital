
namespace Messages
{
    public interface IDirectorMessage
    {
        string Content { get; set; }
        int Type { get; set; }
    }
}
