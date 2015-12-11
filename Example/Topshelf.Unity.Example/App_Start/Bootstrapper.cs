using Microsoft.Practices.Unity;

using Topshelf.Unity.Extensions.Example.Jobs;
using Topshelf.Unity.Extensions.Example.Web;

namespace Topshelf.Unity.Extensions.Example
{
    internal static class Bootstrapper
    {
        public static IUnityContainer CreateContainer()
        {
            return new UnityContainer()
                .RegisterType<IHttpClient, HttpClient>()
                .RegisterType<IJob, CheckGoogleAvailabilityJob>("google")
                .RegisterType<IJob, CheckYandexAvailabilityJob>("yandex");
        }
    }
}
