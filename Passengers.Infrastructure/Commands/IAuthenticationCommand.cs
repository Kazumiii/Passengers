using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Infrastructure.Commands
{
  public  interface IAuthenticationCommand:ICommand
    {
        Guid userIDP { get; set;}

         
    }
}
