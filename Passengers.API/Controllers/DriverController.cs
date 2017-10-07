using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passengers.Infrastructure.Commands;
using Passengers.Infrastructure.Commands.User;
using Passengers.Infrastructure.Commands.Drivers;
using Passengers.Core.Services;
using Microsoft.AspNetCore.Authorization;
using NLog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Passengers.API.Controllers
{
    [Route("api/[controller]")]
    public class DriverController :APIControllserBaescs
    {
        private readonly IDriverService _driverservice;

      
        //in this way I download  logger for class , interface injection is not necessary 
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger(); 
            

        public DriverController(ICommandDispatcher dispatcher,IDriverService service) : base(dispatcher)
            {
            _driverservice = service;

        }


        //returns each driver
        [HttpGet]
        public async Task<IActionResult> Get( )
        {
            _logger.Info("Fetch drivers");
            //BrowseAsync returns each driver 
            var driver = await _driverservice.BrowseAsync();

            return Json(driver);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateDriver command)
        {
            await DispatchAsync(command);

            return NoContent();
        }

        [Authorize]
        [HttpPut("me")]
        public async Task<IActionResult> Put([FromBody]UpdateDriver command)
        {
            await DispatchAsync(command);

            return NoContent();
        }

        //endpoint-download driver
        [HttpGet]
        [Route("{userid}")]
        public async Task<IActionResult>Get(Guid userid)
        {
            var driver = await _driverservice.Get(userid);
            if(driver==null)
            {
                return NotFound();
            }
            return Json(driver);
        }

        [Authorize]
        [HttpDelete("me")]
        public async Task<IActionResult> Post()
        {
            await DispatchAsync(new DeleteDriver());

            return NoContent();
        }



    }

}
