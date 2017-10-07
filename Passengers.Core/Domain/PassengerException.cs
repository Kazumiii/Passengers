using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.Domain
{
 public abstract   class PassengerException:Exception
    {
        public string Code { get; set; }

         //this constructoe will hereited with other class
        protected PassengerException()
        {

        }

        //pass error code
        public PassengerException(string code)
        {
            Code = code;
        }

        //pass extra information but without errorCode
        //and evoke another constructor
        //args' table is used to formatting message 
        public PassengerException(string message,params object[] args):this(string.Empty,message,args)
        {
          
        }

        //pass empty errorCode
        //and evoke antoher constructor
        public PassengerException(string code,string message, params object[] args) : this(null,code,  message, args)
        {
           
        }
        public PassengerException(Exception innerException,  string message, params object[] args) : this(innerException,string.Empty, message, args)
        {

        }
        //we use build Error handlder class
        public PassengerException(Exception innerException,string code, string message, params object[] args) :base( string.Format(message,args), innerException)
        {
            Code = code;
        }
    }
}
