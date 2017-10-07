using Passengers.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Core.Services
{
  public  interface IUserService:IService
    {
     Task<  UserDTO >Get(string email);
        Task Register(Guid id, string email,string userName, string password,string role);
        Task LoginAsync(string email, string paasword);

        //allows overview of users
        Task<IEnumerable<UserDTO>> BrowseAsync();

    }
}
