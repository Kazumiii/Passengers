using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Infrastructure.Commands.User
{
   public class ChangePassword:ICommand
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
