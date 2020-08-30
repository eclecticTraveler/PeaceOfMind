using PeaceOfMind.DataMovement.Dtos;
using PeaceOfMind.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeaceOfMind.Service.Factory
{
    public class ServiceFactory
    {
        public static ISurveyWrapper GetSurveySpecific(int surveyId, IEnumerable<IAnswerDto> answerDtos)
        {
            switch (surveyId)
            {
                case 1:
                    return new DepressionSurvey(answerDtos);
                case 2:
                    return new AnxietySurvey(answerDtos);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
