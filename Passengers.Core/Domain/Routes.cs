using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.Domain
{
 public   class Routes
    {
        public Guid RouteID { get; protected set; }

        public Node StartNode { get; protected set; }

        public Node EndNode { get; protected set; }

        public string RouteName { get; protected set; }

 public double Distance { get; protected set; }



        public Routes(string routeName,Node startNode,Node endNode,double distance)
        {
            RouteName = routeName;
            StartNode =startNode;
            EndNode = endNode;
            Distance = distance;

           
        }

        public static Routes Create(string name, Node start, Node end,double distance)
        => new Routes(name, start, end,distance);

        


    }
}
