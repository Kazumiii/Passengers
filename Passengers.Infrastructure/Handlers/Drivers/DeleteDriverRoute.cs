using Passengers.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Infrastructure.Handlers.Drivers
{
  public  class DeleteDriverRoute:AuthenticateCommandBase
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }



    }
}
