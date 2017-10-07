using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.Services
{
    //value from this class are defined in appsetting.json file 

  public  class jwtSettings
    {
        //it's know only our application
        public string Key { get; set; }

        public string Issuer { get; set; }

        //how long is life of our token
        public int ExpireMinutes { get; set; }
    }
}
