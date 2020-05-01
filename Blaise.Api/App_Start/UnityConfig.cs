using Blaise.Api.Providers;
using Blaise.Core.Factories;
using Blaise.Core.Interfaces;
using Blaise.Core.Services;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.WebApi;

namespace Blaise.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            //configuration
            var configurationProvider = new ConfigurationProvider();

            //services
            container.RegisterType<IPasswordService, PasswordService>();
            container.RegisterType<IParkService, ParkService>();

            //factories
            var connectionConfig = configurationProvider.GetConnectionConfigurationModel();
            container.RegisterSingleton<IConnectedServerFactory, ConnectedServerFactory>(
                new InjectionConstructor(connectionConfig, container.Resolve<PasswordService>()));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

    }
}