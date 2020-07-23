using System.Collections.Generic;
using Blaise.Core.Interfaces;
using Blaise.Nuget.Api.Contracts.Interfaces;
using StatNeth.Blaise.API.ServerManager;

namespace Blaise.Core.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly IFluentBlaiseApi _blaiseApi;

        public SurveyService(IFluentBlaiseApi blaiseApi)
        {
            _blaiseApi = blaiseApi;
        }

        public IEnumerable<ISurvey> GetSurveys()
        {
            return _blaiseApi
                .WithConnection(_blaiseApi.DefaultConnection)
                .Surveys;
        }

        public IEnumerable<ISurvey> GetSurveysByPark(string parkName)
        {
            return _blaiseApi
                .WithConnection(_blaiseApi.DefaultConnection)
                .WithServerPark(parkName)
                .Surveys;
        }

        public void BackupSurveys(string destinationPath)
        {
            var surveys = _blaiseApi
                .WithConnection(_blaiseApi.DefaultConnection)
                .Surveys;

            foreach (var survey in surveys)
            {
                _blaiseApi
                    .WithConnection(_blaiseApi.DefaultConnection)
                    .WithServerPark(survey.ServerPark)
                    .WithInstrument(survey.Name)
                    .Survey
                    .ToPath(destinationPath)
                    .Backup();
            }
        }

        public void BackupSurveysByPark(string parkName, string destinationPath)
        {
            var surveys = _blaiseApi
                .WithConnection(_blaiseApi.DefaultConnection)
                .WithServerPark(parkName)
                .Surveys;

            foreach (var survey in surveys)
            {
                _blaiseApi
                    .WithConnection(_blaiseApi.DefaultConnection)
                    .WithServerPark(survey.ServerPark)
                    .WithInstrument(survey.Name)
                    .Survey
                    .ToPath(destinationPath)
                    .Backup();
            }
        }
    }
}
