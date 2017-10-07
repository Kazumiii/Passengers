 
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Core.Services
{
    //responsible for create and provide routes
  public  interface IDriverRouteServic:IService
    {
        //add route 
        Task Add(Guid userid, string name, double startLatitiude, double endLatitiude, double startLongitiude, double endLongitiude);


       Task DeleteAsync(Guid userID,string name);
    }
}
