using Passengers.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Infrastructure.Handlers.Drivers
{
   public class CreateDriverRoute:AuthenticateCommandBase
    {
    public    Guid userID { get; set; }

        public string RouteName { get; set; }

        public double StartLatitiude { get; set; }

        public double EndLatitiude { get; set; }

        public double StartLongitiude { get; set; }

        public double EndLongitiude { get; set; }
    }
}
