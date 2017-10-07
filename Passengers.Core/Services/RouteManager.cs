using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Core.Services
{
    public class RouteManager : IRouteManager
    {
        private static readonly Random random = new Random();

        public double CalculateDistance(double StartLatitiude,  double StartLongitiude, double EndLatitiude, double EndLongitiude)
        => random.Next(500, 1000);

        public async Task<string> GetAddres(double lati, double longi)
        => await Task.FromResult($"Sample address:{random.Next(100)}.");
    }
}
