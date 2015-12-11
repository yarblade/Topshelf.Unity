using System.Threading;

namespace Topshelf.Unity.Extensions.Example.Jobs
{
    internal interface IJob
    {
        void Execute(CancellationToken cancellationToken);
    }
}
