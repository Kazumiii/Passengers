using Passengers.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Core.Services
{
    //some of methods will return IHandlerTask beceause i want to get a fluent API
  public  interface IHandlerTask
    {
        // let's assume at the end we want to do such operations like  disconnet with database or remove garbages
        IHandlerTask Always(Func<Task> always);

        //i use this method to capture my own Exception (PassengerException)
        //using this method we can be sure we got expcetion from our application level
        //we don't have to casting this exception only hanlde in special way 
        //second parametr is useful when we want to pass around my exception(e.g to the top)
        //by set false value for this parameter we want to keep this exception at this place  
        IHandlerTask OnCustomError(Func<PassengerException,Task>onCustomError,bool propagateException=false,bool ExecuteOnError=false);

        //this is univeral version above mentioned methos which can capture any exception
        IHandlerTask OnError(Func<Exception, Task> onError, bool propagateException = false, bool ExecuteOnError = false);

        //this method will be launched only when our method get success
        IHandlerTask OnSuccess(Func<Task> onSuccess);

        //pass my exception arounds
        IHandlerTask PropageteException();

        //no pass my exception arounds
        IHandlerTask NotProgateException();

        //owing to this method we are not limited to single operation , we can do many operations
        IHandler Next();

        //launch single reffer to method
        Task ExecuteAsync();
    }
}
