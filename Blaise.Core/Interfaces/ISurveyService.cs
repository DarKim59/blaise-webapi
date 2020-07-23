using System.Collections.Generic;
using StatNeth.Blaise.API.ServerManager;

namespace Blaise.Core.Interfaces
{
    public interface ISurveyService
    {
        IEnumerable<ISurvey> GetSurveys();
        IEnumerable<ISurvey> GetSurveysByPark(string parkName);
        void BackupSurveys(string destinationPath);
        void BackupSurveysByPark(string parkName, string destinationPath);
    }
}