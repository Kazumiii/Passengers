using Passengers.Infrastructure.Commands.Drivers.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Infrastructure.Commands.Drivers
{
  public  class CreateDriver:AuthenticateCommandBase
    {
        public Guid UserID { get; set; }

        public DriverVehicle _vehicle;

  


    }
}
