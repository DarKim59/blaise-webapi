
using System.Web.Http;
using Blaise.Nuget.Api.Contracts.Interfaces;
using Unity;
using Unity.WebApi;

namespace Blaise.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IFluentBlaiseApi, IFluentBlaiseApi>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}