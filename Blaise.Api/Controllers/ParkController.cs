using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Blaise.Nuget.Api.Contracts.Interfaces;

namespace Blaise.Api.Controllers
{
    [RoutePrefix("api/v1")]
    public class ParkController : ApiController
    {
        private readonly IFluentBlaiseApi _blaiseApi;

        public ParkController(IFluentBlaiseApi blaiseApi)
        {
            _blaiseApi = blaiseApi;
        }

        [HttpGet]
        [Route("parks")]
        [ResponseType(typeof(IEnumerable<string>))]
        public IHttpActionResult GetParks()
        {
            var parkNames = _blaiseApi.GetServerParkNames();

            return Ok(parkNames);
        }

        [HttpGet]
        [Route("parks/{parkName}/instruments/{instrumentName}/Id")]
        [ResponseType(typeof(Guid))]
        public IHttpActionResult GetInstrumentId(string parkName,string instrumentName)
        {
            var instrumentId = _blaiseApi
                .WithServerPark(parkName)
                .ForInstrument(instrumentName)
                .GetInstrumentId();

            return Ok(instrumentId);
        }
    }
}
