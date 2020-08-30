using System.Collections.Generic;
using PeaceOfMind.DataMovement.Dtos;

namespace PeaceOfMind.Service.Models
{
    public interface ISurveyDerived
    {
        IEnumerable<ISurveyRange> GetRangesForSurveyScale();
        ISurveyResult GetSurveyResults();
        IEnumerable<IAnswer> TransformDtoToModel(IEnumerable<IAnswerDto> answersDtos);
        bool VerifySurveyCompletion();
    }
}