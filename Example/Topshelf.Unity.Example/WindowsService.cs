using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Topshelf.Unity.Extensions.Example.Jobs;

namespace Topshelf.Unity.Extensions.Example
{
    internal class WindowsService : IWindowsService
    {
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly IJob[] _jobs;
        private Task[] _tasks;

        public WindowsService(IJob[] jobs)
        {
            _jobs = jobs;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void Start()
        {
            _tasks = _jobs.Select(x => Task.Run(() => x.Execute(_cancellationTokenSource.Token))).ToArray();
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();

            Task.WaitAll(_tasks, TimeSpan.FromSeconds(20));
        }
    }
}
