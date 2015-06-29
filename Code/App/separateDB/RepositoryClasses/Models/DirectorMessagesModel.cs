using System;

namespace RepositoryClasses.Models
{
    public class DirectorMessagesModel
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime When { get; set; }
        public int Type { get; set; }
    }
}
