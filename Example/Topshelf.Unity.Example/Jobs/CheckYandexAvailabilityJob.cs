using System;
using System.Threading;

using Topshelf.Unity.Extensions.Example.Web;

namespace Topshelf.Unity.Extensions.Example.Jobs
{
    internal class CheckYandexAvailabilityJob : IJob
    {
        private readonly IHttpClient _httpClient;

        public CheckYandexAvailabilityJob(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void Execute(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var response = _httpClient.Get("http://ya.ru");

                Console.WriteLine(!string.IsNullOrEmpty(response) ? "Yandex was available at {0}" : "Yandex was not available at {0}", DateTime.Now);

                Thread.Sleep(TimeSpan.FromSeconds(10));
            }
        }
    }
}
