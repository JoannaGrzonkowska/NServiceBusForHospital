using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.Common
{
    public class CommandResult
    {
        public CommandResult(IEnumerable<string> errors = null)
        {
            Errors = errors == null ? new List<string>() : errors.ToList();
            IsSuccess = !Errors.Any();
        }

        public bool IsSuccess { get; private set; }

        public IEnumerable<string> Errors { get; private set; }
    }
}
