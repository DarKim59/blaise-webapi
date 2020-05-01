
using System.Web.Http;
using System.Web.Http.Description;

namespace Blaise.Api.Controllers
{
    [RoutePrefix("api")]
    public class HealthController : ApiController
    {
        [Route("health")]
        [ResponseType(typeof(bool))]
        public bool HealthCheck()
        {
            return true;
        }
    }
}
