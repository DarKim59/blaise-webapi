using Blaise.Core.Models;
using System;
using System.Configuration;

namespace Blaise.Api.Providers
{
    public class ConfigurationProvider
    {
        public ConnectionConfigurationModel GetConnectionConfigurationModel()
        {
            var configurationModel = new ConnectionConfigurationModel
            {
                ServerName = ConfigurationManager.AppSettings["ServerHostName"],
                UserName = ConfigurationManager.AppSettings["ServerUserName"],
                Password = ConfigurationManager.AppSettings["ServerPassword"],
                Binding = ConfigurationManager.AppSettings["ServerBinding"],
                Port = ConvertToInt(ConfigurationManager.AppSettings["ServerPort"])
            };
            return configurationModel;
        }

        private int ConvertToInt(string integer)
        {
            return Int32.Parse(integer);
        }
    }
}