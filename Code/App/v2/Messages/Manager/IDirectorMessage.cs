using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public interface IDirectorMessage
    {
        int MessageId { get; set; }
        string Content { get; set; }
        int Type { get; set; }
    }
}
