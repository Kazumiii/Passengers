using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;
 

namespace Passengers.Infrastructure.Extensions
{
    public static  class SettongsExtensions
    {
        //limit - only class with  default public constructor (no parameters)
        public static T  GetSettings<T>(this IConfiguration configuration)where T:new ()
        {
            //take name of my type(class) and then remove string Settings (eg. GeneralSettings=> General) and at the end take section 
            //this regarind to appsetting.json class especially genral section 
            //i have remove Settings string form  name GeneralSettng so i get only General 
            //and i have mapping General=>Passenger
            var section = typeof(T).Name.Replace("Settngs", string.Empty);



            //new default obejct of  our configurations
            var convifguationValue = new T();

            //bind values from appseting,json ( .general section) to my configuration 
            configuration.GetSection(section).Bind(convifguationValue);


            //return whole configuration which i have configured 
            return convifguationValue;
        }
    }
}
