using Test.It.ApplicationBuilders;

namespace Test.It
{
    public class ControllerProvidingAppBuilder<TController> : IApplicationBuilder<TController>
    {
        private readonly IApplicationBuilder _appBuilder;

        public ControllerProvidingAppBuilder(IApplicationBuilder appBuilder)
        {
            _appBuilder = appBuilder;
        }

        public TController Controller { get; private set; }

        public IApplicationBuilder WithController(TController controller)
        {
            Controller = controller;
            return _appBuilder;
        }
    }
}