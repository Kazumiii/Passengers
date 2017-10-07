using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Passengers.Infrastructure.Commands.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static System.Net.WebRequestMethods;

namespace Passengers.Test_EndToEnd.Controllers
{
  public  class AccountControllerTest:ControllerTestsBase
    {
        

        [Fact]
        public async Task Given_Valid_Password()
        {
            
            //strong typing data
            var command = new ChangePassword
            {
            CurrentPassword="secret",
            NewPassword  ="secret2",


            };
            var payload = GetPayload(command);
            //query to server 
            var response = await _client.PutAsync("account/password", payload);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NoContent);

             
        }

    }
}
