using Microsoft.AspNetCore.Builder;
 

namespace Passengers.API.Freamwork
{
    //plug myExceptionHandler  in MiddelWare of ASP.NET
    public static class Extensions
    {

        public static IApplicationBuilder  UseExceptionHandlera(this IApplicationBuilder builder)
        =>builder.UseMiddleware(typeof( ExceptionHandler));


        }
    
}
