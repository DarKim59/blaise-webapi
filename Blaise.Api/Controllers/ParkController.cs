using Blaise.Core.Interfaces;
using Blaise.Core.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Blaise.Api.Controllers
{
    [RoutePrefix("api/v1")]
    public class ParkController : ApiController
    {
        private readonly IParkService _parkService;

        public ParkController(IParkService parkService)
        {
            _parkService = parkService;
        }

        [HttpGet]
        [Route("parks")]
        [ResponseType(typeof(IEnumerable<ParkModel>))]
        public IHttpActionResult GetParks()
        {
            var parkNames = _parkService.GetServerParkNames();

            return Ok(parkNames);
        }

        [HttpGet]
        [Route("parks/{parkName}/instruments/{instrumentName}/Id")]
        [ResponseType(typeof(Guid))]
        public IHttpActionResult GetInstrumentId(string parkName,string instrumentName)
        {
            var instrumentId = _parkService.GetInstrumentId(parkName, instrumentName);
            
            return Ok(instrumentId);
        }
    }
}
