using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Core.Services.Handlers
{
    public class HandlerTaskRunner : IHandlerTaskRunner
    {
        private readonly IHandler _handler;

        private readonly ISet<IHandlerTask> _handlerTask;

        private readonly Func<Task> _validate;

        public HandlerTaskRunner(IHandler handler,Func<Task>validate,ISet<IHandlerTask>handlerTask)
        {
            _handler = handler;

            _handlerTask = handlerTask;

            _validate =validate;
        }

        public IHandlerTask Run(Func<Task> run)
        {
            var handler = new HandlerTask(_handler, run);
            _handlerTask.Add(handler);
            return handler;
        }
    }
}
