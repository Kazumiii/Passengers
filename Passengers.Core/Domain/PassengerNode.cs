using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.Domain
{
    //represents points where driver can collet users 
 public   class PassengerNode
    {
        //place where passanger can be collected
        public  Node  Nodes{ get;protected set;}

    public Passenger Passengers { get; protected set; }

        protected PassengerNode()
        {

        }

        public PassengerNode(Passenger passanger,Node node)
        {
            Passengers = passanger;
            Nodes = node;
        }

        public static PassengerNode Create(Passenger passenger, Node node)
            => new PassengerNode(passenger, node);
    }
}
