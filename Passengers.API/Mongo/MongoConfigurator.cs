using MongoDB.Bson.Serialization.Conventions;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
 

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
            ConventionRegistry.Register("PassengerConvention",new MongoConvention(),x=>true);
        }

    }
    
    //here i write my convention
    private class MongoConvention:IConventionPack
    {
 public IEnumerable<IConvention>()=>new List<IConvention>()
 {
 //ignore unserializable elements
 new IgnoreExtraElementsConvention(true),
 
 //we want to write our data in camelCase form convention
 new CamelCaseElementNameConvention(),
 
 //write enum as a string
 new EnumRepresentationConvention(BsonType.String)
 
 
 };
    
}
}
