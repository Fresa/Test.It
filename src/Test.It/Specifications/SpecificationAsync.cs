using System.Threading;
using System.Threading.Tasks;

namespace Test.It.Specifications
{
    public abstract class SpecificationAsync
    {
        protected async Task SetupAsync(CancellationToken cancellationToken = default)
        {
            await GivenAsync(cancellationToken);
            await WhenAsync(cancellationToken);
        }

        protected virtual Task GivenAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        protected virtual Task WhenAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}