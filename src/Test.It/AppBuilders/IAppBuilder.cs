using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Test.It.AppBuilders
{
    public interface IApplicationBuilder
    {
        Func<IDictionary<string, object>, Task> Build();
        void Use(IMiddleware middleware);
    }

    public interface IApplicationBuilder<in TController>
    {
        IApplicationBuilder WithController(TController controller);
    }
}