using Ordering.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationSaga.Hubs
{
    public interface IShowToUIHubService
    {
        void ShowZgloszenieNaWykonanieBadania(ZgloszenieNaWykonanieBadania message);
        void ShowZgloszenieDoLab(ZgloszenieDoLab message);
        void ShowWynikiZLaboratorium(WynikiZLaboratorium message);
    }
}
