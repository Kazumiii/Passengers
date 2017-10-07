using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Core.Services
{

    //due to binding reason IHanlder must inherite from IService 
public    interface IHandler:IService
    {
        //when i launch Run function (from this level) i want do my operation, i can't put validation when my operation is running 
        IHandlerTask Run(Func<Task>run);


        //I want to validate user before he takes any action so that's why Validate function must be evoke at the begining
        //when user is validated i can Run function (that's why IHandlerTaskRunnfer contains Run function )
        IHandlerTaskRunner Validate(Func<Task> validate);

        //we will evoke a few operations and this method will evoke these operatin in asynchronic way 
        Task ExecueAllAsync();
    }
}
