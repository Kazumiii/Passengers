using Passengers.Core.Services;
using Passengers.Infrastructure.Commands;
using Passengers.Infrastructure.Commands.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Infrastructure.Handlers.Users
{//In UserController i had code which was deciding what action should be taken what shouldn't take place that's why 
    //I'm using CommandHandler design pattern that transfer command from controllers to genaral interfaces which will make descion what should be done 
 //I need two interfaces(both of them are limited to only ICommand, can get only ICommand type they  are designed special for commands )  
 // first handle business logice( ICommandHanlder)
 //second  responsible for  sending command to proper handler

  public  class CreateUserHandler : ICommandHandler<CreateUser>
    {

        private readonly IUserService _service;

        public CreateUserHandler(IUserService service)
        {
            _service = service;
        }



        //It defines entire busienss logic 
        public async Task HandleAsync(CreateUser Command)
        {
          await  _service.Register(Guid.NewGuid(),Command.email, Command.UserName, Command.password,Command.role);
        }
    }
}
