﻿
namespace Blaise.Core.Models
{
    public class ConnectionConfigurationModel
    {
        public string ServerName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Binding { get; set; }

        public int Port { get; set; }
    }
}