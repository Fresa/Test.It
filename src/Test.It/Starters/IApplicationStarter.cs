using System.Collections.Generic;
using Test.It.AppBuilders;

namespace Test.It.Starters
{
    public interface IApplicationStarter
    {
        IDictionary<string, object> Start(IApplicationBuilder applicationBuilder);
    }

    public interface IMyApplicationStarter<out TClient>
    {
        IDictionary<string, object> Start(IApplicationBuilder<TClient> applicationBuilder);
    }
}