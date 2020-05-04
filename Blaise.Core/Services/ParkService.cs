
using Blaise.Core.Exceptions;
using Blaise.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blaise.Core.Services
{
    public class ParkService : IParkService
    {
        private readonly IConnectedServerFactory _connectionFactory;

        public ParkService(IConnectedServerFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IEnumerable<string> GetServerParkNames()
        {
            var connection = _connectionFactory.GetConnection();
            var serverParks = connection.ServerParks;

            return serverParks.Select(sp => sp.Name);
        }

        public Guid GetInstrumentId(string instrumentName, string serverParkName)
        {
            var connection = _connectionFactory.GetConnection();
            var serverPark = connection.GetServerPark(serverParkName);
            var survey = serverPark.Surveys.FirstOrDefault(s => string.Equals(s.Name, instrumentName, StringComparison.OrdinalIgnoreCase));

            if (survey == null)
            {
                throw new DataNotFoundException($"Instrument '{instrumentName}' not found on server park '{serverParkName}'");
            }

            return survey.InstrumentID;
        }
    }
}
