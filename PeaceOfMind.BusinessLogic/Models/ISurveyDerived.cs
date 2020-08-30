using System.Collections.Generic;
using PeaceOfMind.DataMovement.Dtos;

namespace PeaceOfMind.Service.Models
{
    public interface ISurveyDerived
    {
        IEnumerable<ISurveyRange> GetRangesForSurveyScale();
        ISurveyResult GetSurveyResults(ISurveyResult surveyResult, IEnumerable<IAnswer> answers);
        string GetSymptomLevelDescription(int totalSurveyPoints);
    }
}