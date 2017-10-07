using Passengers.Core.Repositories;
using Passengers.Core.Services;
using Passengers.Infrastructure.Commands;
using Passengers.Infrastructure.Commands.Drivers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Infrastructure.Handlers.Drivers
{
    public class CreateDriverHandler : ICommandHandler<CreateDriver>
    {
        private readonly IDriverService _service;

        public CreateDriverHandler(IDriverService service)
        {
            _service = service;
        }

        public  async Task HandleAsync(CreateDriver Command)
        {
            await _service.CreateAsync(Command.UserID);
            await _service.SetVehicle(Command.UserID, Command._vehicle.Brand, Command._vehicle.Name);
            
        }
    }
}
