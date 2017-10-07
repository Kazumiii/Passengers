using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Infrastructure.Commands.User
{
  public  class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;

        //context for IoC container in application (from Autofac library)
        public CommandDispatcher(IComponentContext context)
        {
            _context = context;
        }

        //this method make descion where require should be send to be handle correctly 
        public  async Task DispatchAsync<T>(T Command) where T : ICommand
        {
           if(Command==null)
            {
                throw new ArgumentNullException(nameof(Command));
            }

           //context of IoC wher we  can take implementation of our interface
            var handler = _context.Resolve<ICommandHandler<T>>();
        await    handler.HandleAsync(Command);

        }
    }
}
