using Passengers.Core.Services;
using Passengers.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Infrastructure.Handlers.Drivers
{
    public class CreateDriverRoueHandler : ICommandHandler<CreateDriverRoute>
    {
        private readonly IDriverRouteServic _service;

        public CreateDriverRoueHandler(IDriverRouteServic service)
        {
            _service = service;
        }

        public async Task HandleAsync(CreateDriverRoute Command)
        {
            await _service.Add(Command.userID, Command.RouteName, Command.StartLatitiude, Command.EndLatitiude, Command.StartLongitiude, Command.EndLongitiude);

        }
    }
}
