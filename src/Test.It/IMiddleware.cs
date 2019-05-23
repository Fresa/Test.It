using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Test.It
{
    public interface IMiddleware
    {
        void Initialize(Func<IDictionary<string, object>, CancellationToken, Task> next);
        Task Invoke(IDictionary<string, object> environment, 
            CancellationToken cancellationToken = default);
    }
}