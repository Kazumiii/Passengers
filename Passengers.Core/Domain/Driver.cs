using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Core.Domain
{
  public  class Driver
    {
        

        public Guid UserID { get; protected set; }

        public string Name { get; protected set; }

        public Vehicle vehcile { get; protected set; }

        public double Distance { get; protected set; }

        //represnts collecion of all routes 
        public List<Routes> _routes { get; private set; }

        //represnts collection daily routes of driver
        public IEnumerable<DailyRoute> DailyRoutes { get; protected set; }
        public DateTime UpdateAt { get; private set; }

        protected Driver()
        {

        }

        public Driver(User user)
        {

            Name = user.FullName;
            UserID = user.ID;
        }

       public   void SetVehicle(Vehicle vehicle)
        {
            vehcile = vehcile;
            UpdateAt = DateTime.UtcNow; 
        }

        public void AddRoute(string name,Node startPoint,Node endPoint,double distance)
        {
            _routes.Add(Routes.Create(name, startPoint, endPoint,distance));
        
            UpdateAt = DateTime.UtcNow;
        }

        public void deleteRoute(string name)
        {
            var route = _routes.SingleOrDefault(x => x.RouteName == name);
            _routes.Remove(route);
            UpdateAt = DateTime.UtcNow;
        }
           
        
    }


}
