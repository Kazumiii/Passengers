using MongoDB.Bson.Serialization.Conventions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.Mongo
{
    //this class contains variables which must get initialize only once - after launched of application
 public static   class MongoConfigurator
    {
        private static bool _initialize;

        public static void Initialize()
        {
            if (_initialize)
                return;
            else
            {

            }

        }
        //it says how to write data inside the database
        public static void RegisterConvenction()
        {
            ConventionRegistry.Registry("PassengerConvention",);
        }

    }
}
