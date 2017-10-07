using Passengers.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Passengers.Core.DTO;
using AutoMapper;
using System.Threading.Tasks;
using Passengers.Core.Domain;
using Passengers.Core.Services.Extensions;
using Passengers.Core.Exceptions;

namespace Passengers.Core.Services
{
    public class DriverService : IDriverService
    {
        private readonly IUserRepository _Userrepository;


        private readonly IVehicleProvider _provider;

        private readonly IDriverRepository _driverrepositroy;

        private readonly IMapper _mapper;

        public DriverService(IDriverRepository repo,IMapper mapa,IUserRepository Userrepo,IVehicleProvider provider)
        {
            _provider = provider;

            _Userrepository = Userrepo;
            _driverrepositroy = repo;
            _mapper = mapa;
        }

        public async Task<IEnumerable<DriversDetailsDTO>> BrowseAsync()
        {
            var driver =await  _driverrepositroy.GetAll();
            return _mapper.Map<IEnumerable<Driver>,IEnumerable< DriversDetailsDTO>>(driver);
        }

        public  async Task CreateAsync(Guid id)
        {
            var user = await _Userrepository.UserGetOrFail(id);
 

            var driver = await _driverrepositroy.Get(id);
            if(driver!=null)
            {
                //second parametr is only extra communicate , the most imporatant is fisrt paramter which is erroCode
                //errorCode can be capture and handle very easily on the client side 
                throw new ServiceException(ErrorCode.InvalidDriver,"Driver with this id alredy exist");
            }
            driver = new Driver(user);
          await  _driverrepositroy.Add(driver);
            
            
        }

        public async Task DeleteAsync(Guid userIDP)
        {
            var driver =await _driverrepositroy.Get(userIDP);
            if(driver!=null)
            {
                await _driverrepositroy.Delete(driver);
            }
        }

        public async Task< DriversDetailsDTO >Get(Guid Userid)
        {
            var driver2 =await _driverrepositroy.Get(Userid);
            return _mapper.Map< Driver,DriversDetailsDTO>(driver2);

        }

        public async  Task SetVehicle(Guid userid, string brand, string name)
        {
            var driver = await _driverrepositroy.DriverGetOrFail(userid);
          
            var vehicle =await  _provider.GetAsyn(name, brand);
          var vehicle2=  Vehicle.Create(brand, name, vehicle.Seats);
            driver.SetVehicle(vehicle2);
            await _driverrepositroy.Udpate(driver);
        }

      
    }
}
