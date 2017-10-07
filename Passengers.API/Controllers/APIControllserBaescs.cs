using Microsoft.AspNetCore.Mvc;
using Passengers.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passengers.API.Controllers
{
    [Route("[controller]")]
    public abstract class APIControllserBaescs:Controller
    {
        //ICommandDispatcher will be used be each controller
        private readonly ICommandDispatcher _dispatcher;

        //ID for authenticated user
        protected Guid userID => User?.Identity?.IsAuthenticated == true ? Guid.Parse(User.Identity.Name) : Guid.Empty;

       protected APIControllserBaescs(ICommandDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        //it allows hidden implementation regarding to sending our comments
protected async Task DispatchAsync<T>(T command)where T:ICommand
        {
            if(command is IAuthenticationCommand AuthencticateCommand)
            {
                //put   identificator numver of user which is log in 
                //Owin to this we always get uerID by token
                AuthencticateCommand.userIDP =userID ;
       
                //I have created DispatchAsync method that hidden _dispatcher field

            }
            await _dispatcher.DispatchAsync(command);
        }

       

    }
}
