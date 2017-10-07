using Passengers.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.DTO
{
  public  class RouteDTO
    {
        public Guid RouteID { get; set; }

        public Node StartNode { get;  set; }

        public Node EndNode { get;  set; }

        public double Distance { get; set; }
    }
}
