using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Test_EndToEnd.Controllers
{
  public abstract  class ControllerTestsBase
    {

        protected readonly HttpClient _client;

        protected readonly TestServer _server;

        protected ControllerTestsBase()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<StartupBase>());
            _client = _server.CreateClient();
        }


        //serialize stringo into JSON form
        protected static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            //to inform server it got json object
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
