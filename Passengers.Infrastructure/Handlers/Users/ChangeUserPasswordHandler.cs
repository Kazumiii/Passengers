using Passengers.Infrastructure.Commands;
using Passengers.Infrastructure.Commands.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Infrastructure.Handlers.Users
{
    public class ChangeUserPasswordHandler : ICommandHandler<ChangePassword>
    {
        public  async Task HandleAsync(ChangePassword Command)
        {
            await Task.CompletedTask;
        }
    }
}
