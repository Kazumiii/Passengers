using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Core.Services
{
    public class DataInitialize : IDataInitialize
    {
        private IDriverService _driverservice;

private IDriverRouteServic _driverRouteService;
        private readonly IUserService _service;

        private readonly ILogger<DataInitialize> _logger;
        
        public DataInitialize(IUserService service, ILogger<DataInitialize> logger,IDriverService driverservice)
            {
            _driverservice = driverservice;
            _service = service;
            _logger = logger;

            }

        //this method creates users
        public async Task Sead()
        {
        
        var user=await _service.BrowseAsync();
        
        if(user.Any())
        {
        
        //we don't want to re-initialize users
        return;
        }
            _logger.LogTrace("Initializing data...");

//i want to be sure users will be register fisr then drivers and so on  to get such sequence i use await 
            //Register method is asynchronus methodso i need await parametr but to don't copycat many times
            //this operator i creat  List<Task> and i will launch all data when i collected all 
            var task = new List<Task>();
            for(var i=0;i<10;i++)
            {
                var id = Guid.NewGuid();
                var userName = $"user{i}";
                await _service.Register(userid,$"user{i}@test.com"username,"secret","user");
                _logger.LogTrace($"Created user:'{userName}' ");
                   await _driverservice.CreateAsync(userid);
                       await _driverservice.SetVehicle(id, "BMw", "i8"));
                        _logger.LogTrace($"Adding driver for:'{userName}' ");
                        await _driverRouteService.Add(userid,"defaultRoute",1,1,2,2);
                             await _driverRouteService.Add(userid,"Job Route",3,4,7,8);
         _logger.LogTrace($"Adding route for:'{userName}' ");
                
            }

            for (var i = 0; i < 3; i++)
            {
                var id = Guid.NewGuid();
                var userName = $"admin{i}";
                _logger.LogTrace($"Created admin:'{userName}; ");
                task.Add(_service.Register(id, "admin@gmail.com", "AdminName", "secret", "admin"));
            }
            await Task.WhenAll(task);

            _logger.LogTrace("Data was initialized");
        }

    }
}
