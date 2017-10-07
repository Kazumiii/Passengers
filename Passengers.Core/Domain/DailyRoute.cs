using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Passengers.Core.Domain
{

    //Route's taken by driver -single route 
 public   class DailyRoute
    {

        private ISet<PassengerNode> _passengerNode = new HashSet<PassengerNode>();

        public Guid ID { get; protected set; }

        public Routes Route { get; protected set; }


        //this gives us information where driver shuld stop and who need a lift 
        public IEnumerable<PassengerNode> PassengersNodes { get
            {
                return _passengerNode;
            }
            protected set
            {
                _passengerNode = new HashSet<PassengerNode>(value);
            }
                
                }

        protected DailyRoute()
        {
            ID = Guid.NewGuid();
        }


        public void AddPassengerNode(Passenger passanger,Node node)
        {
            var pass = GetPassenger(passanger);
            if(pass!=null)
            {
                throw new  InvalidOperationException("user already exists");
            }
            _passengerNode.Add(PassengerNode.Create(passanger, node));

        }

        public void RemovePassengerNode(Passenger passenger)
        {
            var pass = GetPassenger(passenger);
            if(pass==null)
            {
                return;
            }
            _passengerNode.Remove(pass);
        }

        public PassengerNode GetPassenger(Passenger passenger)
        => _passengerNode.SingleOrDefault(x => x.Passengers.UserID == passenger.UserID);
        
       

    }
}
