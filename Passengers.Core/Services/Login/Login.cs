using Passengers.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.Services.Login
{
   public class Login:ICommand
    {
        public Guid TokenID { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
