using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Blaise.Api.Providers;
using Google.Cloud.Diagnostics.AspNet;

namespace Blaise.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        public override void Init()
        {
            base.Init();
            var configurationProvider = new ConfigurationProvider();
            // Trace a sampling of incoming Http requests.
            CloudTrace.Initialize(this, configurationProvider.ProjectId);
        }
    }
}
