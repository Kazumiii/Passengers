using AutoMapper;
using Passengers.Core.Domain;
using Passengers.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Infrastructure.Mapper
{

    //it's responsible only for configuration
  public static  class AutoMapperConfig
    {
        //it returns AutoMapper object (responsible for mapping process)
        public static  IMapper Initialize()
          =>new MapperConfiguration(x =>
          {
              //maping user  on userDTO 
              x.CreateMap<User, UserDTO>();

              x.CreateMap<Node, NodeDTO>();

              x.CreateMap<Routes, RouteDTO>();

              x.CreateMap<Vehicle, VehicleDTO>();

              x.CreateMap<Driver, DriversDetailsDTO>();
              //mappint drivero n driverDTO
              x.CreateMap<Driver, DriverDTO>();
 }).CreateMapper();//I have created new configuration of my mapper 




        
    }
}
