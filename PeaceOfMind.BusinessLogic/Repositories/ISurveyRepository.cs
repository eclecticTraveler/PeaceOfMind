using System;
using System.Collections.Generic;
using PeaceOfMind.Service.Models;

namespace PeaceOfMind.Service.Repositories
{
    public interface ISurveyRepository
    {
        IEnumerable<ISurvey> GetAvailableDistinctSurveys();
        IEnumerable<IQuestion> GetSurveyQuestions(int surveyId, IEnumerable<IQuestion> questions);
        void SaveSurveyResult(ISurveyResult surveyResult);
        IEnumerable<ISurveyResult> GetSurveyResultsPerPeriod(DateTime minDate, DateTime maxDate);
    }
}