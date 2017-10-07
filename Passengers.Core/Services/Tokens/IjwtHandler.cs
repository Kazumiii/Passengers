using Passengers.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.Services
{
    //handles tokens-generates tokens
 public   interface IjwtHandler
    {
        jwtDTO CreateToken(Guid userID,string role);
    }
}
