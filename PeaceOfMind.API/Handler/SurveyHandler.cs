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
        private ISurveyManager _surveyManager;

        public SurveyHandler(ISurveyManager surveyManager)
        {
            _surveyManager = surveyManager;
        }

        public IEnumerable<IQuestionDto> GetSurveyQuestions(int surveyId)
        {
            var surveys = _surveyManager.FetchSurveyQuestions(surveyId);
            return surveys;
        }


        public IEnumerable<ISurveyDto> GetAvailableSurveys()
        {
            var surveys = _surveyManager.FetchAvailableSurveys();
            return surveys;
        }

        public ISurveyResultDto ProcessSurveyAnswers(int surveyId, IEnumerable<IAnswerDto> answerDtos)
        {
            return _surveyManager.ProcessSurveyAnswers(surveyId, answerDtos);         
        }
    }
}
