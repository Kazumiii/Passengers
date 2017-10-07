using Passengers.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Passengers.Core.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Passengers.Core.Services
{
    class InMemoryDrvierRepository :IDriverRepository
    {

        private static ISet<Driver> _driver=new HashSet<Driver>();

       

        public async Task Add(Driver driver)
        {
            _driver.Add(driver);
            await Task.CompletedTask;
        }

        public async Task Delete(Driver driver)
        => _driver.Remove(driver);
        

        public async Task< Driver> Get(Guid userid)
        => await Task.FromResult(_driver.Single(x => x.UserID == userid));
        

        public async Task<  IEnumerable<Driver>>GetAll()
    => await Task.FromResult( _driver);

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Udpate(Driver driver)
        {
            throw new NotImplementedException();
        }
    }
}
