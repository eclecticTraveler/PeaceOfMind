using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeaceOfMind.DataMovement.Dtos;

namespace PeaceOfMind.Service.Models
{
    public abstract class Survey : ISurvey
    {
        public string SurveyName { get; set; }
        public int SurveyId { get; set; }
        public DateTime DateCompleted { get; set; }
        public bool IsSurveyCompleted { get; set ; }
        public bool IsSurveyStarted { get; set; }
        public int LastQuestionCompleted { get; private set; } = -1;
        public IEnumerable<IQuestion> Questions { get; set; }
        public int TotalNumOfQuestions { get; }
        public int TotalAvailablePoints { get; }
        public int UserTotalPoints { get; }

        public abstract IEnumerable<IAnswer> TransformDtoToModel(IEnumerable<IAnswerDto> answersDtos);
        public abstract bool VerifySurveyCompletion();


    }
}
