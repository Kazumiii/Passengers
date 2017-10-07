using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.Mongo
{
 public   class MongoSettings
    {
        //defines URL to database
        //set in appsettings.json file
        public string connectionString { get; set; }

        //call of database
        public string DataBase { get; set; }
    }
}
