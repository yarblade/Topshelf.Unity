using Microsoft.Practices.Unity;

using Topshelf.HostConfigurators;
using Topshelf.Unity.WindowsServices;

namespace Topshelf.Unity.Extensions
{
    public static class HostConfiguratorExtensions
    {
        public static HostConfigurator RunService<T>(this HostConfigurator configurator, IUnityContainer container) where T : class, IWindowsService
        {
            return configurator.Service<T>(
                serviceConfigurator =>
                {
                    serviceConfigurator.ConstructUsing(serviceFactory => container.Resolve<T>());
                    serviceConfigurator.WhenStarted(service => { service.Start(); });
                    serviceConfigurator.WhenStopped(
                        service =>
                        {
                            service.Stop();
                            container.Dispose();
                        });
                });
        }
    }
}
