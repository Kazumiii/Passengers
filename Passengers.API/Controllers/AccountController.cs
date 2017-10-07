using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Passengers.Infrastructure.Commands;
using Passengers.Core.Services;
using Passengers.Infrastructure.Commands.User;
using Microsoft.AspNetCore.Authorization;

namespace Passengers.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    //this controller represtnes user's account 
    public class AccountController : APIControllserBaescs
    {
        private readonly IjwtHandler _handler;

        public AccountController( ICommandDispatcher dispatcher,IjwtHandler handler) : base(dispatcher)
        {

            _handler = handler;
        }
  


      



        [HttpGet]
        [Route("token")]
        public async Task<IActionResult> Get([FromBody]ChangePassword password)
        {
            await DispatchAsync(password);

            return NoContent();
        }

    }
}