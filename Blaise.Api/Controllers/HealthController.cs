
using System.Web.Http;
using System.Web.Http.Description;

namespace Blaise.Api.Controllers
{
    [RoutePrefix("api/v1")]
    public class HealthController : ApiController
    {
        [HttpGet]
        [Route("health")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult HealthCheck()
        {
            return Ok();
        }
    }
}
