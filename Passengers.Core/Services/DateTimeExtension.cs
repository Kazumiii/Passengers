using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.Services
{
    public static class DateTimeExtension
    {
        //this method extents standard DateTime class to use Linux epoch format to save data in JwtHandler class during  settings Claims for our token
        public static long ToTimestamp(this DateTime datatime)
        {

            //epoch must be set form 1970 year ( Linux creation date)
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);


            //diffrence between Linux creation date and present date 
            var time = datatime.Subtract(new TimeSpan(epoch.Ticks));

            return time.Ticks / 10000;
        }
    }
}
