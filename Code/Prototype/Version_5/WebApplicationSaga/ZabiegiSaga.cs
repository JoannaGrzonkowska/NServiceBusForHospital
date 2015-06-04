using NServiceBus;
using NServiceBus.Saga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ordering.Shared;
using WebApplicationSaga.Hubs;

namespace WebApplicationSaga
{
    public class ZabiegiSaga : Saga<ZabiegiSagaData>,
        IAmStartedByMessages<ZgloszenieNaWykonanieBadania>,
        IHandleMessages<WynikiZLaboratorium>
    {
        private IShowToUIHubService _showToUIHubService;

        public ZabiegiSaga()
        {
            _showToUIHubService = new ShowToUIHubService();
        }

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<ZabiegiSagaData> mapper)
        {
            mapper.ConfigureMapping<ZgloszenieNaWykonanieBadania>(s => s.IdPacjenta)
                    .ToSaga(m => m.IdPacjenta);
            mapper.ConfigureMapping<WynikiZLaboratorium>(s => s.IdPacjenta)
                   .ToSaga(m => m.IdPacjenta);
        }

        public void Handle(ZgloszenieNaWykonanieBadania message)
        {
            base.Data.IdPacjenta = message.IdPacjenta;
            _showToUIHubService.ShowZgloszenieNaWykonanieBadania(message);

            var zgloszenieDoLab = new ZgloszenieDoLab{
               IdPacjenta = message.IdPacjenta,
               IdBadania = 1
            };
            base.Bus.Send(zgloszenieDoLab);

            _showToUIHubService.ShowZgloszenieDoLab(zgloszenieDoLab);
        }

        public void Handle(WynikiZLaboratorium message)
        {
            base.Data.IdPacjenta = message.IdPacjenta;
            _showToUIHubService.ShowWynikiZLaboratorium(message);

            base.ReplyToOriginator(new WynikiDlaPacjenta
            {
                Wynik = message.Wynik
            });
            MarkAsComplete();
        }

    }
}