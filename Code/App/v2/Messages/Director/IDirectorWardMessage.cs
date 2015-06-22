using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.Director
{
    public interface IDirectorWardMessage
    {
        int MessageId { get; set; }
        string Content { get; set; }
    }
}
