using DataMovement.Dtos;
using PeaceOfMind.DataMovement.Dtos;
using System;
using System.Collections.Generic;

namespace PeaceOfMind.Service.Models
{
    public interface ISurvey
    {
        DateTime DateCompleted { get; set; }
        bool IsSurveyCompleted { get; set; }
        int LastQuestionCompleted { get; }
        IEnumerable<IQuestion> Questions { get; set; }
        int TotalNumOfQuestions { get; }
        int TotalAvailablePoints { get; }
        int UserTotalPoints { get; }
        bool VerifySurveyCompletion(IEnumerable<IQuestion> questions);
        int GetSurveyPoints(IEnumerable<IAnswer> answers);
        IEnumerable<IQuestion> GetSurveyQuestions(int surveyId, IEnumerable<IQuestion> questions);
        IEnumerable<IAnswer> TransformAnswersDtoToModel(IEnumerable<IAnswerDto> answersDtos);
        IEnumerable<IAnswerDto> TransformAnswersModelToDto(IEnumerable<IAnswer> answers);
        IEnumerable<IQuestion> TransformQuestionsDtoToModel(IEnumerable<IQuestionDto> questionsDto);
        IEnumerable<IQuestionDto> TransformQuestionsModelToDto(IEnumerable<IQuestion> questions);
        ISurveyResult TransformSurveyResultDtoToModel(ISurveyResultDto surveyResultDto);
        ISurveyResultDto TransformSurveyResultModelToDto(ISurveyResult surveyResult);


    }
}