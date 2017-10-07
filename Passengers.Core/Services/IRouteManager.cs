using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Core.Services
{
public    interface IRouteManager:IService
    {

        //get addres from outside service
        Task<string> GetAddres(double lati, double longi);


        double CalculateDistance(double StartLatitiude, double StartLongitiude, double EndLatitiude, double EndLongitiude);
    }
}
