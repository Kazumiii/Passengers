using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Infrastructure.Commands.User
{
public    class CreateUser:AuthenticateCommandBase
    {

        public string role { get; set; }

        public string email { get; set; }

        public string password { get; set; }

       public string UserName { get; set; }
    }
}
