using Blaise.Core.Interfaces;
using Blaise.Core.Models;
using StatNeth.Blaise.API.ServerManager;
using System;

namespace Blaise.Core.Factories
{
    public class ConnectedServerFactory : IConnectedServerFactory
    {
        private readonly ConnectionConfigurationModel _configurationModel;
        private readonly IPasswordService _passwordService;

        private IConnectedServer _connectedServer;

        public ConnectedServerFactory(
            ConnectionConfigurationModel configurationModel,
            IPasswordService passwordService)
        {
            _configurationModel = configurationModel;
            _passwordService = passwordService;
        }

        public IConnectedServer GetConnection()
        {
            if (_connectedServer == null)
            {
                CreateServerConnection(_configurationModel);
            }

            return _connectedServer;
        }

        private void CreateServerConnection(ConnectionConfigurationModel configurationModel)
        {
            _connectedServer = ServerManager.ConnectToServer(
                configurationModel.ServerName,
                configurationModel.Port,
                configurationModel.UserName,
                _passwordService.CreateSecurePassword(configurationModel.Password),
                configurationModel.Binding);
        }

        IConnectedServer IConnectedServerFactory.GetConnection()
        {
            throw new NotImplementedException();
        }
    }
}
