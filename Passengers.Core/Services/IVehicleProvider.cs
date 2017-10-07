using Passengers.Core.Domain;
using Passengers.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Core.Services
{
public    interface IVehicleProvider:IService
    {
        Task<IEnumerable<VehicleDTO>> BrowseAsync();

        Task<VehicleDTO> GetAsyn(string name, string brand);
    }
}
