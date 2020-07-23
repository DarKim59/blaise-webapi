using System;
using System.Configuration;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;
using System.Web.Http;
using Blaise.Api.Filters;
using Blaise.Api.Providers;
using Google.Cloud.Diagnostics.AspNet;

namespace Blaise.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Add a catch all for the uncaught exceptions.
            // Replace ProjectId with your Google Cloud Project ID.
            // Replace Service with a name or identifier for the service.
            // Replace Version with a version for the service.

#if DEBUG
            var credentialKey = ConfigurationManager.AppSettings["GOOGLE_APPLICATION_CREDENTIALS"];

            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialKey);

#endif

            var configurationProvider = new ConfigurationProvider();
            config.Services.Add(typeof(System.Web.Http.ExceptionHandling.IExceptionLogger),
                ErrorReportingExceptionLogger.Create(
                    configurationProvider.ProjectId,
                    configurationProvider.ServiceName, 
                    configurationProvider.ServiceVersion));

            //exception filter
            config.Filters.Add(new CustomExceptionFilterAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                       name: "DefaultApi",
                       routeTemplate: "v1/{controller}/{id}",
                       defaults: new { id = RouteParameter.Optional });

            config.Formatters.JsonFormatter.SupportedMediaTypes
               .Add(new MediaTypeHeaderValue("text/html"));

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

            UnityConfig.RegisterComponents();
        }
    }
}
