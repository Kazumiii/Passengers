using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Core.Services
{
 public   interface IHandlerTaskRunner
    {
        //when user launches Run function from this level i can be sure user was validated
        IHandlerTask Run(Func<Task> run);

    }
}
