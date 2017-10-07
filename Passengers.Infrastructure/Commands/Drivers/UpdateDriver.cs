using Passengers.Infrastructure.Commands.Drivers.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Infrastructure.Commands.Drivers
{
public    class UpdateDriver:AuthenticateCommandBase
    {

        public DriverVehicle vehicle { get; set; }
    }
}
