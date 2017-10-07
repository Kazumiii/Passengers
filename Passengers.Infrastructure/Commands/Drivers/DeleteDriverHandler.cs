using Passengers.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Infrastructure.Commands.Drivers
{
    public class DeleteDriverHandler : ICommandHandler<DeleteDriver>
    {
      private readonly IDriverService _service;

        public DeleteDriverHandler(IDriverService service)
        {
            _service = service;
        }

        public async Task HandleAsync(DeleteDriver Command)
        {
            _service.DeleteAsync(Command.userIDP);
        }
    }
}
