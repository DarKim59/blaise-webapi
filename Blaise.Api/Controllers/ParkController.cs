using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Blaise.Core.Interfaces;
using Google.Cloud.Diagnostics.AspNet;

namespace Blaise.Api.Controllers
{
    [RoutePrefix("api/v1")]
    public class ParkController : ApiController
    {
        private readonly IParkService _parkService;
        private readonly IWebApiExceptionLogger _exceptionLogger;

        public ParkController(
            IParkService parkService,
            IWebApiExceptionLogger exceptionLogger)
        {
            _parkService = parkService;
            _exceptionLogger = exceptionLogger;
        }

        [HttpGet]
        [Route("parks")]
        [ResponseType(typeof(IEnumerable<string>))]
        public IHttpActionResult GetParks()
        {
            try
            {
                using (CloudTrace.Tracer.StartSpan("GetParks"))
                {
                    var parks = _parkService.GetParks().ToList();

                    Console.Out.WriteLine($"Successfully received a list of server parks '{string.Join(", ", parks)}'");

                    //throw new Exception($"There was an error in calling 'GetParks'");
                    return Ok(parks);
                }
            }
            catch (Exception e)
            {
                _exceptionLogger.Log(e, ActionContext);
                throw;
            }
        }
    }
}
