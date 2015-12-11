using System;
using System.IO;

namespace Topshelf.Unity.Extensions.Example
{
    internal class Program
    {
        private static void Main()
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

            HostFactory.Run(
                hostConfigurator =>
                {
                    hostConfigurator.RunAsLocalSystem();

                    hostConfigurator.RunService<WindowsService>(Bootstrapper.CreateContainer());
                });
        }
    }
}
