using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.DTO
{

    //keeps token's data
   public  class jwtDTO
    {
        public string Token { get; set; }

        public long Expire { get; set; }

    }
}
