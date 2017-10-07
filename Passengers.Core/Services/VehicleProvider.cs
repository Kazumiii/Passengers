using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Passengers.Core.Domain;
using Passengers.Core.DTO;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;

namespace Passengers.Core.Services
{
    public class VehicleProvider : IVehicleProvider
    {
        //for each string i have list of availabe vehicles
        private static readonly IDictionary<string, IEnumerable<VehicleDetails>> _availableVehicles = new Dictionary<string, IEnumerable<VehicleDetails>>
        {
            ["Audi"]=new List<VehicleDetails>()
            {
                new VehicleDetails("Rs8",4),
            },
            ["BMw"] = new List<VehicleDetails>()
            {
                new VehicleDetails("i8",3),
                new VehicleDetails("E36",4),
            },
            ["Ford"] = new List<VehicleDetails>()
            {
                new VehicleDetails("Fieta",5),
            },

        };
 

        private readonly IMemoryCache _cache;

       
        private readonly static string CacheKey = "vehicle";

        public async Task<IEnumerable<VehicleDTO>> BrowseAsync()
        {
            var vehicle = _cache.Get<IEnumerable<VehicleDTO>>(CacheKey);
            if(vehicle==null)
            {
                //send query to database or outside service and save result in cache to speed up access
                var vehicles = await GetAllAsync();
                _cache.Set(CacheKey, vehicles);
            }
            return vehicle;
        }


        //asking the source of data 
        //converting _availableVehicles dictionary  to IEnumerable<VehicleDetails> 
        public async Task<IEnumerable<VehicleDTO>> GetAllAsync()
        => await Task.FromResult(_availableVehicles.GroupBy(x => x.Key)
            .SelectMany(g => g.SelectMany(v => v.Value
              .Select(c => new VehicleDTO
              {
                  Brand=v.Key,
                  Name=c.Name,
                  Seats=c.Seats,

              }))));
        




        public  async Task<VehicleDTO> GetAsyn(string name, string brand)
        {
            if(!_availableVehicles.ContainsKey(brand))
            {
                throw new Exception($"Vehicle brand'{brand}' is not available");
            }
            //take all vehicles by key
            var vehicles = _availableVehicles[brand];
            //take vehicle be name
            var vehicle = vehicles.SingleOrDefault(x => x.Name == name);

            if(vehicle==null)
            {
                throw new Exception($"Vehicle'{name}' for brand '{brand}' does not exist");
            }

            return await Task.FromResult (new VehicleDTO
            {
                Brand=brand,
                Name=vehicle.Name,
                Seats=vehicle.Seats
            });

        }



        public VehicleProvider(IMemoryCache cache)
        {
            _cache = cache;
        }


        private class VehicleDetails
        {
            public int Seats { get; set; }

            public string Name { get; set; }

            public VehicleDetails(string name,int seats)
            {
                
                Name = name;
                Seats = seats;

            }
        }

        
    }
}
