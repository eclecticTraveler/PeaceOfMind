using System.Collections.Generic;
using DataMovement.Dtos;
using PeaceOfMind.DataMovement.Dtos;

namespace PeaceOfMind.API.Handlers
{
    public interface ISurveyHandler
    {
        IEnumerable<ISurveyDto> GetAvailableSurveys();
        IEnumerable<IQuestionDto> GetSurveyQuestions(int surveyId);
        ISurveyResultDto ProcessSurveyAnswers(int surveyId, IEnumerable<IAnswerDto> answerDtos);

    }
}