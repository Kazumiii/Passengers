using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passengers.Infrastructure.Commands;
using Passengers.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Passengers.API.Controllers
{
    [Route("api/[controller]")]
    public class VehiclesController : APIControllserBaescs
    {
        private readonly ICommandDispatcher _dispatcher;

        private readonly IVehicleProvider _provider;

       public VehiclesController(ICommandDispatcher dispatcher,IVehicleProvider provider):base(dispatcher)
        {
          
            _provider = provider;
        }

        //endpoint in API that retunrs list of availabe of vehicles
        public async Task<IActionResult>Get()
        {
            var vehicles =await _provider.BrowseAsync();
            return Json(vehicles);
        }
    }
}
