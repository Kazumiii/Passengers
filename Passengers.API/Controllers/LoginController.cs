using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passengers.Infrastructure.Commands;
using Microsoft.Extensions.Caching.Memory;
using Passengers.Core.Services.Login;
using Passengers.Core.Services.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Passengers.API.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : APIControllserBaescs
    {
        private readonly IMemoryCache _cache;

        public LoginController(ICommandDispatcher dispatcher,IMemoryCache cache):base(dispatcher)
        {
            _cache = cache;
        }

        //single endpoint to login process
        public async Task<IActionResult>Post([FromBody]Login command)
        {
            //server will be responsible for create new token's ID
            command.TokenID = Guid.NewGuid();

            await DispatchAsync(command);

            //downloading token
           var jwt= _cache.GetJwt(command.TokenID);

            return Json(jwt);

        }

    }
}
