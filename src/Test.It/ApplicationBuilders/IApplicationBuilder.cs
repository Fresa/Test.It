using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Test.It.ApplicationBuilders
{
    public interface IApplicationBuilder
    {
        Func<IDictionary<string, object>, CancellationToken, Task> Build();
        void Use(IMiddleware middleware);
    }

    public interface IApplicationBuilder<in TController>
    {
        IApplicationBuilder WithController(TController controller);
    }
}