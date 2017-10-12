using Passengers.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Passengers.Core.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Passengers.Core.Services
{
    public class InMemoryUserRepository : IUserRepository
    {
//hash set collection contains only unique data
        private static ISet<User> _users = new HashSet<User>();
     /*   {
           new User ("user1@gmail.com","User1","secret","salt"),
            new User("user2@gmail.com","User2 " ,"secret","salt"),
        new User("User3@gmail.com","User3","secret","salt"),

        };*/

        public async Task Add(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task<  User> Get(string email)
        {
            return  await Task.FromResult(_users.SingleOrDefault(x => x.Email == email));
        }

        public async Task< User> Get(Guid id)
        {
         return  await Task.FromResult(_users.Single(x => x.ID == id));
        }

        public async Task< IEnumerable<User>> GetAll()
        {
            return await Task.FromResult( _users);
        }

        public  async Task Remove(Guid ID)
        {
            var user2 = await Get(ID);
            _users.Remove(user2);
            await Task.CompletedTask;
    }

        public async Task Update(User user)
        {
            await Task.CompletedTask;
        }
    }
}
