using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using Passengers.Core.Exceptions;

namespace Passengers.API.Freamwork
{
    public class ExceptionHandler
    {

        private readonly RequestDelegate _next;


        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                //try do it what is requiring in HTTP  require  if you get error send  detail information to user 
                await _next(context);

            }

            catch(Exception ex)
            {
                await HandleErrorAsync(context, ex);
            }
        }

        //this method processing errors, it gives us information what has gone wrong: error's number and information
        private static Task HandleErrorAsync(HttpContext context,Exception exception)
        {
            //errorCode cna be use to translate error's message for user's  native language 
            //suport for many languages
            //errorCode can be easily capture on client side and then can be handle , message inside Excpetion remain only extra communicate 
            var errorCode = "error";
            var StatusCode = HttpStatusCode.BadRequest;
            var exceptionType = exception.GetType();
            switch(exception)
            {
                case Exception e when exceptionType == typeof(UnauthorizedAccessException):
                    {
                        StatusCode = HttpStatusCode.Unauthorized;
                        break;
                    }
                case ServiceException e when exceptionType == typeof(ServiceException):
                    {
                        StatusCode = HttpStatusCode.BadRequest;
                        errorCode = e.Code;
                        break;
                    }
                default:
                    {
                        StatusCode = HttpStatusCode.InternalServerError;
                        break;
                    }
            }
            //return error to client
            var response =  new
            {
                code = StatusCode,
                message =exception.Message,
            };

            var payload = JsonConvert.SerializeObject(response);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)StatusCode;

            return context.Response.WriteAsync(payload);
        }


    }
}
