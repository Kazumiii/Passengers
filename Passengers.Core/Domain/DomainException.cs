using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.Domain
{

    //specialize Exception in domain
   public class DomainException:PassengerException
    {
      

      
        protected DomainException()
        {

        }

        
        public DomainException(string code):base(code)
        {
             
        }

         
        public DomainException(string message, params object[] args):base(string.Empty,message,args)
        {

        }

        
        public DomainException(string code, string message, params object[] args) : base(null,code,  message, args)
        {

        }
        public DomainException(Exception innerException, string message, params object[] args) : base(innerException,string.Empty, message, args)
        {

        }
        
        public DomainException(Exception innerException, string code, string message, params object[] args) :base( code,string.Format(message,args), innerException)
        {
             
        }

    }
}
