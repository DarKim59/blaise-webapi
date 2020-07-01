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
            var parkNames = _blaiseApi.ServerParks;

            return Ok(parkNames);
        }
    }
}
