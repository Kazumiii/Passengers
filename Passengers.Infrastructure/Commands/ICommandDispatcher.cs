using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Infrastructure.Commands
{
    //responsible for sending command to proepr handler
  public  interface ICommandDispatcher
    {
         
        Task DispatchAsync<T>(T Command)where T: ICommand;
    }
}
