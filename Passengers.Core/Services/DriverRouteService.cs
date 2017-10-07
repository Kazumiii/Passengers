using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Passengers.Core.Repositories;
using Passengers.Core.Domain;
using System.Threading.Tasks;

namespace Passengers.Core.Services
{
    //handle routes
    public class DriverRouteService : IDriverRouteServic
    {
        private readonly IDriverRepository _driverRepository;

        private readonly IRouteManager _manager;

        private IMapper _mapper;


        public DriverRouteService(IDriverRepository driverRepository, IMapper mapper,IRouteManager manager)
        {
            _driverRepository = driverRepository;
          
            _mapper = mapper;

            _manager = manager;
        }


        //add new routes
        public async Task Add(Guid userid, string name, double startLatitiude, double endLatitiude, double startLongitiude, double endLongitiude)
        {
            var driver = await _driverRepository.Get(userid);
            if(driver==null)
            {
                throw new Exception("Driver with user ID: " + userid + " not exist");
            }

            var StartAddress =await _manager.GetAddres(startLatitiude, startLongitiude);

            var EndAddress = await _manager.GetAddres(endLatitiude, endLongitiude);

            var start = Node.Create(StartAddress,startLatitiude,startLongitiude);

            var end = Node.Create(EndAddress, endLatitiude, endLongitiude);


            var distance = _manager.CalculateDistance(startLatitiude,startLongitiude, endLatitiude, endLongitiude);

            driver.AddRoute(name, start, end,distance);
            await _driverRepository.Udpate(driver);

        }
         
        public async Task DeleteAsync(Guid userID, string name)
        {
            var driver = await _driverRepository.Get(userID);
            if(driver==null)
            {
                throw new Exception("Driver not exist");

            }
            driver.deleteRoute(name);
            await _driverRepository.Udpate(driver);
         

           
        }
    }
}
