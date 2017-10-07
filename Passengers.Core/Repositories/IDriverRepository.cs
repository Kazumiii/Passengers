using Passengers.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Core.Repositories
{
    public interface IDriverRepository:IRepository
    {
       Task< Driver> Get(Guid UserId);

      Task<  IEnumerable<Driver> >GetAll();

        Task Add(Driver driver);

        Task Udpate(Driver driver);

        Task Remove(Guid id);

        Task Delete(Driver driver);
        
    }
}
