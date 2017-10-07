using Passengers.Core.Services;
using Passengers.Infrastructure.Commands.Drivers.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Infrastructure.Commands.Drivers
{
    public class UpdateDriverHandler : ICommandHandler<UpdateDriver>
    {

        private readonly IDriverService _service;

        public UpdateDriverHandler(IDriverService service)
        {
            _service = service;
        }

        public async Task HandleAsync(UpdateDriver Command)
        {
            await _service.SetVehicle(Command.userIDP, Command.vehicle.Brand, Command.vehicle.Name);
        }
    }
}
