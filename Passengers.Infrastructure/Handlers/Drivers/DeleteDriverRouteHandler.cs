using Passengers.Core.Services;
using Passengers.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Infrastructure.Handlers.Drivers
{
  public  class DeleteDriverRouteHandler:ICommandHandler<DeleteDriverRoute>
    {
        private readonly IDriverRouteServic _service;

        public DeleteDriverRouteHandler(IDriverRouteServic service)
        {
            _service = service;
        }

        public async Task HandleAsync(DeleteDriverRoute Command)
        {
            _service.DeleteAsync(Command.UserId, Command.Name);
        }
 
    }
}
