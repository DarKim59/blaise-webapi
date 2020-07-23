using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Blaise.Api.Models;
using Blaise.Core.Interfaces;
using Google.Cloud.Diagnostics.AspNet;
using StatNeth.Blaise.API.ServerManager;

namespace Blaise.Api.Controllers
{
    [RoutePrefix("api/v1")]
    public class SurveyController : ApiController
    {
        private readonly ISurveyService _surveyService;
        private readonly IWebApiExceptionLogger _exceptionLogger;

        public SurveyController(
            ISurveyService surveyService, 
            IWebApiExceptionLogger exceptionLogger)
        {
            _surveyService = surveyService;
            _exceptionLogger = exceptionLogger;
        }

        [HttpGet]
        [Route("surveys")]
        [ResponseType(typeof(IEnumerable<ISurvey>))]
        public IHttpActionResult GetSurveys()
        {
            try
            {
                return Ok(_surveyService.GetSurveys());
            }
            catch (Exception e)
            {
                _exceptionLogger.Log(e, ActionContext);
                throw;
            }
        }

        [HttpGet]
        [Route("parks/{parkName}/surveys")]
        [ResponseType(typeof(IEnumerable<ISurvey>))]
        public IHttpActionResult GetSurveysByPark([FromUri] string parkName)
        {
            try
            {
                return Ok(_surveyService.GetSurveysByPark(parkName));
            }
            catch (Exception e)
            {
                _exceptionLogger.Log(e, ActionContext);
                throw;
            }
        }

        [HttpPost]
        [Route("surveys/backup")]
        public IHttpActionResult BackupSurveys([FromBody] BackupModel backupModel)
        {
            try
            {
                _surveyService.BackupSurveys(backupModel.DestinationPath);
                
                return Ok();
            }
            catch (Exception e)
            {
                _exceptionLogger.Log(e, ActionContext);
                throw;
            }
        }

        [HttpPost]
        [Route("parks/{parkName}/surveys/backup")]
        public IHttpActionResult BackupSurveysByPark([FromUri] string parkName, [FromBody] BackupModel backupModel)
        {
            try
            {
                _surveyService.BackupSurveysByPark(parkName, backupModel.DestinationPath);
                
                return Ok();
            }
            catch (Exception e)
            {
                _exceptionLogger.Log(e, ActionContext);
                throw;
            }
        }
    }
}
