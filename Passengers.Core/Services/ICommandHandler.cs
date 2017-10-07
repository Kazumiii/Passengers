using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Infrastructure.Commands
{
    //responsible for  handle business logic each requires
   public interface ICommandHandler<T> where T: ICommand
    {
        Task HandleAsync(T Command);

    }
}
