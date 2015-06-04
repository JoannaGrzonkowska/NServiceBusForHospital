using BusinessLogic.Models.Commands;
using NServiceBus;
using Ordering.Shared;
using Ordering.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplicationLaboratorium.Controllers.Api
{
    public class LabController : ApiController
    {
        IBus bus;

        public LabController(IBus bus)
        {
            this.bus = bus;
        }

        [HttpPost]
        public CommandResult WyslijWynikZLab(WynikZLabCommand command)
        {
            try
            {
                var wynikiZLaboratorium = new WynikiZLaboratorium
                {
                    Wynik = command.Wynik,
                    Opis = command.Opis,
                    IdPacjenta = 1
                };
                bus.Send(wynikiZLaboratorium);
            }
            catch(Exception ex)
            {
                new CommandResult(new[] { ex.ToString() });
            }
            return new CommandResult();
        }

        [HttpGet]
        public CommandResult Test()
        {
            try
            {
            }
            catch (Exception ex)
            {
                new CommandResult(new[] { ex.ToString() });
            }
            return new CommandResult();
        }
    }
}
