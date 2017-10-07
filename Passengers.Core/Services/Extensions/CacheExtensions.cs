using Microsoft.Extensions.Caching.Memory;
using Passengers.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.Services.Extensions
{
   public static  class CacheExtensions
    {
        //this method is using to store our token 
        public static void SetJwt(this IMemoryCache cache, Guid tokenID, jwtDTO jwt)
            //setting our unique key,token and definies life time of our token
            //token is taken during authentication process and then is needen't 
            => cache.Set(getJwtKey(tokenID), jwt, TimeSpan.FromSeconds(5));

        //downoloading our cache
        public static jwtDTO GetJwt(this IMemoryCache cache, Guid tokenID)
            => cache.Get<jwtDTO>(getJwtKey(tokenID));

        //it's responislbe for create proper key
        public static string getJwtKey(Guid tokenID)
            => $"jwt.{tokenID}";
            
        
    }
}
