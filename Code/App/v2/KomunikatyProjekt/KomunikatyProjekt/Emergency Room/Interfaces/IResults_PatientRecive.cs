using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomunikatyProjekt.Emergency_Room.Interfaces
{
    public interface IResults_PatientRecive:ICommand
    {
        string Comment { get; set; }
    }
}
