using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataMovement.Dtos;
using Microsoft.AspNetCore.Mvc;
using PeaceOfMind.API.Factory;
using PeaceOfMind.DataMovement.Dtos;
using PeaceOfMind.Service.Managers;

namespace PeaceOfMind.API.Handlers
{
    public class SurveyHandler : ISurveyHandler
    {
        public SurveyHandler()
        {
        }

        public IEnumerable<IQuestionDto> GetSurveyQuestions(int surveyId)
        {
            ISurveyManager manager = ApiFactory.CreateSurveyManager();
            var surveys = manager.FetchSurveyQuestions(surveyId);
            return surveys;
        }


        public IEnumerable<ISurveyDto> GetAvailableSurveys()
        {
            ISurveyManager manager = ApiFactory.CreateSurveyManager();
            var surveys = manager.FetchAvailableSurveys();
            return surveys;
        }

        public SurveyResultDto ProcessSurveyAnswers(int surveyId, IEnumerable<IAnswerDto> answerDtos)
        {
            ISurveyManager manager = ApiFactory.CreateSurveyManager();
            manager.ProcessSurveyAnswers(surveyId, answerDtos);
            throw new NotImplementedException();
        }
    }
}
