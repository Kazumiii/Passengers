using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Core.Services.Handlers
{
    public class Handler : IHandler
    {
        //collecetion of tasks to do
        private readonly ISet<IHandlerTask> _handlerTask = new HashSet<IHandlerTask>();


        public async Task ExecueAllAsync()
        {
  foreach(var task in _handlerTask)
            {
                await task.ExecuteAsync();
            }
            //clear collcetion to make it available for next tasks
            _handlerTask.Clear();
        }

        public IHandlerTask Run(Func<Task> run)
        {
            var handler = new HandlerTask(this, run);
            _handlerTask.Add(handler);

            return handler;

        }

        public IHandlerTaskRunner Validate(Func<Task> validate)
     => new HandlerTaskRunner(this, validate,_handlerTask);
    }
}
