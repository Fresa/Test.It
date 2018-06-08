using System.Collections.Generic;
using Test.It.ApplicationBuilders;

namespace Test.It.Starters
{
    public interface IApplicationStarter
    {
        IDictionary<string, object> Start(IApplicationBuilder applicationBuilder);
    }

    public interface IApplicationStarter<out TClient>
    {
        IDictionary<string, object> Start(IApplicationBuilder<TClient> applicationBuilder);
    }
}