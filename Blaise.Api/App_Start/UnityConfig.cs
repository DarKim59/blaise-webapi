
using System;
using System.Configuration;
using System.Web.Http;
using Blaise.Api.Interfaces;
using Blaise.Api.Providers;
using Blaise.Core.Interfaces;
using Blaise.Core.Services;
using Blaise.Nuget.Api;
using Blaise.Nuget.Api.Contracts.Interfaces;
using Google.Api;
using Google.Cloud.Diagnostics.AspNet;
using Unity;
using Unity.WebApi;

namespace Blaise.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            var configurationProvider = new ConfigurationProvider();
            container.RegisterFactory<IWebApiExceptionLogger>(f =>
                GoogleWebApiExceptionLogger.Create(
                    configurationProvider.ProjectId,
                    configurationProvider.ServiceName,
                    configurationProvider.ServiceVersion));

            container.RegisterType<IFluentBlaiseApi, FluentBlaiseApi>();
            container.RegisterType<IConfigurationProvider, ConfigurationProvider>();
            container.RegisterType<IParkService, ParkService>();
            container.RegisterType<ISurveyService, SurveyService>();

#if DEBUG
            var credentialKey = ConfigurationManager.AppSettings["GOOGLE_APPLICATION_CREDENTIALS"];

            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialKey);

#endif

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}