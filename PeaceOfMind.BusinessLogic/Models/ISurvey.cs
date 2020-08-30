using PeaceOfMind.DataMovement.Dtos;
using System;
using System.Collections.Generic;

namespace PeaceOfMind.Service.Models
{
    public interface ISurvey
    {
        DateTime DateCompleted { get; set; }
        bool IsSurveyCompleted { get; set; }
        bool IsSurveyStarted { get; set; }
        int LastQuestionCompleted { get; }
        IEnumerable<IQuestion> Questions { get; set; }
        int TotalNumOfQuestions { get; }
        int TotalAvailablePoints { get; }
        int UserTotalPoints { get; }
        bool VerifySurveyCompletion();
        IEnumerable<IAnswer> TransformDtoToModel(IEnumerable<IAnswerDto> answersDtos);
    }
}