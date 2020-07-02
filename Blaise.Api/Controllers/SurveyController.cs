using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Blaise.Api.Models;
using Blaise.Nuget.Api.Contracts.Interfaces;
using StatNeth.Blaise.API.ServerManager;

namespace Blaise.Api.Controllers
{
    [RoutePrefix("api/v1")]
    public class SurveyController : ApiController
    {
        private readonly IFluentBlaiseApi _blaiseApi;

        public SurveyController(IFluentBlaiseApi blaiseApi)
        {
            _blaiseApi = blaiseApi;
        }

        [HttpGet]
        [Route("surveys")]
        [ResponseType(typeof(IEnumerable<ISurvey>))]
        public IHttpActionResult GetSurveys()
        {
            var surveys = _blaiseApi.Surveys;

            return Ok(surveys);
        }

        [HttpPost]
        [Route("surveys/backup")]
        public IHttpActionResult BackupSurveys([FromBody] BackupModel backupModel)
        {
            var surveys = _blaiseApi.Surveys;

            foreach (var survey in surveys)
            {
                _blaiseApi
                    .WithServerPark(survey.ServerPark)
                    .WithInstrument(survey.Name)
                    .Survey
                    .ToPath(backupModel.DestinationPath)
                    .Backup();
            }

            return Ok();
        }
    }
}
