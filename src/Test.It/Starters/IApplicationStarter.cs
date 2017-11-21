using System.Collections.Generic;
using Owin;
using Test.It.AppBuilders;

namespace Test.It.Starters
{
    public interface IApplicationStarter
    {
        IDictionary<string, object> Start(IAppBuilder applicationBuilder);
    }

    public interface IApplicationStarter<out TClient>
    {
        IDictionary<string, object> Start(IAppBuilder<TClient> applicationBuilder);
    }
}