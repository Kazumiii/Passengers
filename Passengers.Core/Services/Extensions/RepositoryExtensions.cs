using Passengers.Core.Domain;
using Passengers.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Core.Services.Extensions
{
  public static  class RepositoryExtensions
    {
        public static async Task<Driver>DriverGetOrFail(this IDriverRepository repository,Guid userID)
        {
            var driver = await repository.Get(userID);
            if(driver==null)
            {
                throw new Exception("Driver not exist");
            }
            return driver;
        }

        public static async Task<User> UserGetOrFail(this IUserRepository repository, Guid userID)
        {
            var user = await repository.Get(userID);
            if (user == null)
            {
                throw new Exception("User not exist");
            }
            return user;
        }

    }
}
