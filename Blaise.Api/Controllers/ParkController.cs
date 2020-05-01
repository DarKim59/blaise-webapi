using Blaise.Core.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Blaise.Api.Controllers
{
    [RoutePrefix("api")]
    public class ParkController : ApiController
    {
        [Route("parks")]
        [ResponseType(typeof(IEnumerable<ParkModel>))]
        public IHttpActionResult GetParks()
        {
            return Ok(new List<ParkModel> { new ParkModel { Name = "TestCase" } });
        }

        [Route("parks/{parkName}/instruments/{instrumentName}/Id")]
        [ResponseType(typeof(Guid))]
        public IHttpActionResult GetInstrumentId(string parkName,string instrumentName)
        {
            return Ok(Guid.NewGuid());
        }

    }
}
