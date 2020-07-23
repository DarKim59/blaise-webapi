using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Blaise.Core.Interfaces;
using Blaise.Nuget.Api.Contracts.Interfaces;
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
                return Ok(_parkService.GetParks());
            }
            catch (Exception e)
            {
                _exceptionLogger.Log(e, ActionContext);
                throw;
            }
        }
    }
}
