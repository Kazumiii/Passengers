using Passengers.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Core.Repositories
{
 public   interface IUserRepository:IRepository
    {

       Task< User> Get(string email);

      Task<  User> Get(Guid id);


        //save user in database
        Task Add(User user);

        Task Remove(Guid ID);

        Task Update(User user);

       Task< IEnumerable<User>> GetAll();
    }
}
