using System.Threading;
using System.Threading.Tasks;

namespace Test.It.Specifications
{
    public abstract class SpecificationAsync
    {
        protected async Task SetupAsync(CancellationToken cancellationToken = default)
        {
            await GivenAsync(cancellationToken)
                .ConfigureAwait(false);
            await WhenAsync(cancellationToken)
                .ConfigureAwait(false);
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