
using System.Configuration;
using Blaise.Api.Interfaces;

namespace Blaise.Api.Providers
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        public string ProjectId => ConfigurationManager.AppSettings["ProjectId"];
        public string ServiceName => ConfigurationManager.AppSettings["ServiceName"];
        public string ServiceVersion => ConfigurationManager.AppSettings["ServiceVersion"];
    }
}
