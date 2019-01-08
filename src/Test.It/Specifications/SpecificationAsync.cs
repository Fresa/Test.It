using System.Threading.Tasks;

namespace Test.It.Specifications
{
    public abstract class SpecificationAsync
    {
        protected async Task SetupAsync()
        {
            await GivenAsync();
            await WhenAsync();
        }

        protected virtual Task GivenAsync()
        {
            return Task.CompletedTask;
        }

        protected virtual Task WhenAsync()
        {
            return Task.CompletedTask;
        }
    }
}