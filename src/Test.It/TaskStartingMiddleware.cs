using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Test.It
{
    public class TaskStartingMiddleware : IMiddleware
    {
        private readonly Action _bootup;
        private Func<IDictionary<string, object>, CancellationToken, Task> _next;

        public TaskStartingMiddleware(Action bootup)
        {
            _bootup = bootup;
        }

        public void Initialize(Func<IDictionary<string, object>, CancellationToken, Task> next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment, CancellationToken cancellationToken = default)
        {
            await Task.Run(_bootup, cancellationToken);

            if (_next != null)
            {
                await _next(environment, cancellationToken);
            }
        }
    }
}