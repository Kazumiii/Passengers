using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Passengers.Core.Domain;

namespace Passengers.Core.Services.Handlers
{
   public class HandlerTask:IHandlerTask
    {

        //beceause i pass _handler   i got access to methods of IHandler interface
        //when i launch Run function (from IHandle level) i get acccess to methods of IHandlerTask interface
        //so i get acccess to  another Next function , i can use this function to evoke methods of IHandler interface again and again
        private readonly IHandler _handler;

        private readonly Func<Task> _run;

        private Func<Task> _validate;

        private Func<Task> _always;

        private Func<Task> _onSucces;

        private Func<Exception, Task> _exceptionGeneral;

        private Func<PassengerException, Task> _passengerException;

        private bool _propagateExcepion = true;

        private bool _executeOnError = true;

        //it defines what will be launched (second parameter)
        //assigns Valdaiton operation to _validate variable
        public HandlerTask(IHandler handler,Func<Task>run,Func<Task>validate=null)
        {
            _handler = handler;

            _run = run;

            _validate = validate;
        }

      //assigns to _always variable this what should happen
        public IHandlerTask Always(Func<Task> always)
        {
            _always = always;
            return this;
        }

        //make validation (if it is necessery)
        //launch service
        //if service succeed evoke _onSuccess method
        //if we get excpetion we can pass that exception around
        //at the end even (if we got exception) we launh _always method 
        public async Task ExecuteAsync()
        {
            try
            {
                if (_validate != null)
                {
                    await _validate();
                }
                await _run();

                if(_onSucces!=null)
                {
                    await _onSucces();
                }

            }
            catch(Exception exception)
            {
                await HandleExceptionAsync(exception);
                if(_propagateExcepion)
                {
                    //pass exception around
                    throw;
                }
            }
            finally
            {
                if(_always!=null)
                {
                    await _always();
                }
            }
            
        }


        private async Task HandleExceptionAsync(Exception exception)
        {
            //whether exception is cusotmerException
            var customException=exception as PassengerException;
            //wheter we have exception, if yes  ...
            if (customException!=null)
            {
                //wheter excpetion is client's excpetion ( PassengerException) 
                if(_passengerException!=null)
                {
                    await _passengerException(customException);
                }
            }
            //wheter continue operation regerdless of exception
            var executeOnError = _executeOnError || _passengerException == null;
            if(!executeOnError)
            {
                return;
            }

            if(_exceptionGeneral!=null)
            {
                await _exceptionGeneral(exception);
            }
        }

        public IHandler Next()
    => _handler;
    
        public IHandlerTask NotProgateException()
        {
            _propagateExcepion = false;
            return this ;
        }

        public IHandlerTask OnCustomError(Func<PassengerException, Task> onCustomError, bool propagateException = false, bool ExecuteOnError = false)
        {
           _passengerException = onCustomError;
            _propagateExcepion = propagateException;
            _executeOnError = ExecuteOnError;

            return this;
        }

        public IHandlerTask OnError(Func<Exception, Task> onError, bool propagateException = false, bool ExecuteOnError = false)
        {
            _exceptionGeneral = onError;
            _propagateExcepion = propagateException;
            _executeOnError = ExecuteOnError;

            return this;
        }

        public   IHandlerTask OnSuccess(Func<Task> onSuccess)
        {
            _onSucces = onSuccess;
            return  this; 
        }

        public IHandlerTask PropageteException()
        {
            _propagateExcepion = true;
            return this;
        }
    }
}
