using Passengers.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.DTO
{
   public class DriversDetailsDTO:DriverDTO
    {
        public IEnumerable<RouteDTO> DailyRoutes { get;  set; }



    }
}
