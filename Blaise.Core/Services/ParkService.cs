using System.Collections.Generic;
using Blaise.Core.Interfaces;
using Blaise.Nuget.Api.Contracts.Interfaces;

namespace Blaise.Core.Services
{
    public class ParkService : IParkService
    {
        private readonly IFluentBlaiseApi _blaiseApi;

        public ParkService(IFluentBlaiseApi blaiseApi)
        {
            _blaiseApi = blaiseApi;
        }

        public IEnumerable<string> GetParks()
        {
           return _blaiseApi
                .WithConnection(_blaiseApi.DefaultConnection)
                .ServerParks;
        }
    }
}
