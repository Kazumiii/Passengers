using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Passengers.API;
using Passengers.Core.DTO;
using Passengers.Infrastructure.Commands.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Passengers.Test_EndToEnd.Controllers
{
    class UserControllerTest:ControllerTestsBase
    {
        
        //test API method

        [Fact]
        public async Task Given_Valid_Email()
        {
            var email = "user@gmail.com";
            /*I get users
            var response = await _client.GetAsync($"users/{email}");

                //checking if response from serer is correct 
            response.EnsureSuccessStatusCode();


            //take response in string form
            var responseString = await response.Content.ReadAsStringAsync();

    */
            //I write string like object 
            var user = await GetUserAync(email);

            user.Email.ShouldBeEquivalentTo(email);

           

            //I have created API in memeory with full refrencces, interfacess and so on.
            //I check does user exist using  integration test 
        }

        //it gives us information user can't be found 
        public async Task Given_Invalid_Email()
        {
            var email = "user1000@gmail.com";
            var response=await _client.GetAsync($"user/{email}");
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NotFound);
        }

        //it creates query to API to find user

        [Fact]
        public async Task Given_Unique_User()
        {
            var email = "test@gmail.com";
            //strong typing data
            var request = new CreateUser
            {
                email = "test@gmial.com",
                UserName = "test",
            password="secret",


            };
            var payload = GetPayload(request);
            //query to server 
            var response = await _client.PostAsync("users",payload);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Created);

            //to check  response contains  location header
            response.Headers.Location.ToString().ShouldBeEquivalentTo($"users/{request.email}");
 
            var user = await GetUserAync(request.email);
            user.Email.ShouldAllBeEquivalentTo(request.email);
        }


        //to be sure user exist 
        private async Task<UserDTO>GetUserAync(string email)
        {
            var esponse = await _client.GetAsync($"users/{email}");
            var responseString = await esponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserDTO>(responseString);
        }

        
    }
}
