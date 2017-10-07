using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.Domain
{
 public   class Passenger
    {

        public Guid ID { get; protected set; }

        public Guid UserID { get; protected set; }

        //place to collect passenger
       public Node Adress { get; protected set; }
       

    }
}
