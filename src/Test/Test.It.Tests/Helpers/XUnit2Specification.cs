using Test.It.Specifications;

namespace Test.It.Tests.Helpers
{
    public abstract class XUnit2Specification : Specification
    {
        protected XUnit2Specification()
        {
            Setup();
        }
    }
}