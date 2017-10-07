using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Infrastructure.Commands
{
    public class AuthenticateCommandBase : IAuthenticationCommand
    {
        public Guid userIDP { get; set; }
    }
}
