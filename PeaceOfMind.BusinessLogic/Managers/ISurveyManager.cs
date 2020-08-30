using System.Collections.Generic;
using DataMovement.Dtos;
using PeaceOfMind.DataMovement.Dtos;

namespace PeaceOfMind.Service.Managers
{
    public interface ISurveyManager
    {
        IEnumerable<ISurveyDto> FetchAvailableSurveys();
        IEnumerable<IQuestionDto> FetchSurveyQuestions(int surveyId);
        ISurveyResultDto ProcessSurveyAnswers(int surveyId, IEnumerable<IAnswerDto> answerDtos);

    }
}