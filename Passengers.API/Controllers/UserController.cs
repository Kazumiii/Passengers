using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passengers.Core.Services;
using Passengers.Core.DTO;
using Passengers.Infrastructure.Commands.User;
using Passengers.Infrastructure.Commands;
using Passengers.Infrastructure.Settings;
using Microsoft.AspNetCore.Authorization;
 
//in this project i use CQS design patern- separte writing mechanism from reading mechanism

namespace Passengers.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : APIControllserBaescs
    {
        private readonly IUserService serviceRepo;


        private readonly ICommandDispatcher dispatcher;

       public UserController (IUserService service,ICommandDispatcher dispatch ):base(dispatch)
        {
            serviceRepo = service;
             
        }

        //returns each user
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await serviceRepo.BrowseAsync();
            return Json(user); 
        }


        // GET api/values/5
        //I use IActionResult to return HTTP code
        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user= await serviceRepo.Get(email);

            if(user==null)
            {
                return NotFound();
            }
            return Json(user);
        }

        //[FromBody] is necessary to ASP.NET Core knows  to HTTP reguires ( in JASON form)will be put  to these data   
        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CreateUser command )
        {
            //owing to this mehod i cna remove whole bussines logic form controller and delegate it to other part of application which are responsible fot it 
            await DispatchAsync(command);

            //I use CommandHandler design pattern so i don't need this line of code 
            // insted of this i use Disptach metohod (from ICommandDisptacher) which make descion where this command should be send 
            //_service.Register(Command.email, Command.UserName, Command.password);

            //when operation will be successful we will download our user form this path 
            return Created($"users/{command.email}",null);
        }

      

    }
}
