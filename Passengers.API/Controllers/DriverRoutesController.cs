using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passengers.Infrastructure.Commands;
using Passengers.Infrastructure.Handlers.Drivers;
using Passengers.Infrastructure.Commands.User;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Passengers.API.Controllers
{
    [Route("drivers/[routes]")]
    public class DriverRoutesController : APIControllserBaescs
    {
        private readonly CommandDispatcher _dispatcher;

       
        public DriverRoutesController(ICommandDispatcher dispatcher):base(dispatcher)
        {

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult>Post([FromBody]CreateDriverRoute command)
        {
            await DispatchAsync(command);
            return NoContent();
        }


        [Authorize]
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            var command = new DeleteDriverRoute()
            {
                Name = name,
            };
            await DispatchAsync(command);
            return NoContent();
        }
    }
}
