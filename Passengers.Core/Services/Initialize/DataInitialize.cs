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
            _logger.LogTrace("Initializing data...");


            //Register method is asynchronus methodso i need await parametr but to don't copycat many times
            //this operator i creat  List<Task> and i will launch all data when i collected all 
            var task = new List<Task>();
            for(var i=0;i<10;i++)
            {
                var id = Guid.NewGuid();
                var userName = $"user{i}";
                _logger.LogTrace($"Created user:'{userName}; ");
                task.Add(_service.Register(id,"user@gmail.com","UserName","secret","user"));
                //inicialization
                task.Add(_driverservice.CreateAsync(id));
                task.Add(_driverservice.SetVehicle(id, "BMw", "i8"));
                
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
