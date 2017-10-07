using Microsoft.Extensions.Caching.Memory;
using Passengers.Core.Services.Extensions;
using Passengers.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Core.Services.Login
{
    public class LoginHandler : ICommandHandler<Login>
    {
        //using IHandler i can get more dynamic in  login process
        private readonly IHandler _handlerOperation;

        private readonly IUserService _service;

        private readonly IjwtHandler _handler;

        //cache mechanism
        //it's keepng in API memory
        private readonly IMemoryCache _cache;


        public LoginHandler(IHandler handlerOperation,IUserService service,IjwtHandler handler,IMemoryCache cache)
        {
            _handlerOperation = handlerOperation;

            _service = service;  

            _handler = handler;

            _cache = cache;
        }
        //this method make the same things like HandleAsync method by use IHandler ( to get more advanced way- i can see each operation) 
        //by use Next() i can evoke other Run()
        //at the end execute all operation in asynchronic way
        public async Task Handle(Login Command)
     => await _handlerOperation
            .Run(async () => await _service.LoginAsync(Command.Email, Command.Password))
        .Next()
        .Run(async () =>
        {

            var user = await _service.Get(Command.Email);


            var jwt = _handler.CreateToken(user.ID, user.Role);


            _cache.SetJwt(Command.TokenID, jwt);
        }).ExecuteAsync();

        public async Task HandleAsync(Login Command)
        {
            await _service.LoginAsync(Command.Email, Command.Password);

                var user = await _service.Get(Command.Email);

            //role of our user
            var jwt = _handler.CreateToken(user.ID, user.Role);

            //save our token inside cache
            //it's working similar to dictionary 
            //we need extension method
            _cache.SetJwt(Command.TokenID, jwt); 
        }
    }
}
