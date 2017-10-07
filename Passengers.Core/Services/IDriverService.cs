using Passengers.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Core.Services
{
    public interface IDriverService : IService
    {
        Task<DriversDetailsDTO> Get(Guid Userid);


        Task CreateAsync(Guid id);

        Task SetVehicle(Guid userid, string brand, string name);
        Task<IEnumerable<DriversDetailsDTO>> BrowseAsync();
        Task DeleteAsync(Guid userIDP);
       
    }
}
