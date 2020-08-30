using DataMovement.Dtos;
using PeaceOfMind.DataMovement.Dtos;
using PeaceOfMind.Service.Factory;
using PeaceOfMind.Service.Models;
using PeaceOfMind.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeaceOfMind.Service.Managers
{
    public class SurveyManager : ISurveyManager
    {
        public IEnumerable<ISurveyDto> FetchAvailableSurveys()
        {
            var surveyRepo = ServiceFactory.CreateSurveyRepo();
            var surveys = surveyRepo.GetAvailableDistinctSurveys();
            return TransformSurveysToDtos(surveys);         
        }

        public ISurveyResultDto ProcessSurveyAnswers(int surveyId, IEnumerable<IAnswerDto> answerDtos)
        {
            // Here is where threads are nice to save to the DB answers while processing takes place
            if (answerDtos == null)
            {
                throw new System.ArgumentException("answers object is null");
            }
            var survey = ServiceFactory.GetSurveySpecific(surveyId, ServiceFactory.CreateMapper(), ServiceFactory.CreateSurveyRepo());
            var surveyAnswers = survey.TransformAnswersDtoToModel(answerDtos);
            var surveyResult = survey.GetSurveyResults(ServiceFactory.CreateSurveyResult(), surveyAnswers);
            //Save in DB only if authenticated
            return survey.TransformSurveyResultModelToDto(surveyResult);
        }

        public IEnumerable<IQuestionDto> FetchSurveyQuestions(int surveyId)
        {
            if (surveyId < 0)
            {
                throw new System.ArgumentException("survey Id is not valid");
            }

            var survey = ServiceFactory.GetSurveySpecific(surveyId, ServiceFactory.CreateMapper(), ServiceFactory.CreateSurveyRepo());
            // TODO : handle the questions intantiated list with IoC same up in results
            var surveyQuestions = survey.GetSurveyQuestions(surveyId);
            return survey.TransformQuestionsModelToDto(surveyQuestions);
        }
        private IEnumerable<ISurveyDto> TransformSurveysToDtos(IEnumerable<ISurvey> surveys)
        {
            var surveyListDto = ServiceFactory.CreateSurveyListDto().ToList();
            foreach (var survey in surveys)
            {
                if (survey is DepressionSurvey depressionSurvey)
                {
                    surveyListDto.Add(
                    new SurveyDto
                    {
                        SurveyId = depressionSurvey.SurveyId,
                        SurveyName = depressionSurvey.SurveyName,
                        SurveyApiPath = $"/{depressionSurvey.SurveyName}"
                    });
                }
                else if (survey is AnxietySurvey anxietySurvey)
                {
                    surveyListDto.Add(
                    new SurveyDto
                    {
                        SurveyId = anxietySurvey.SurveyId,
                        SurveyName = anxietySurvey.SurveyName,
                        SurveyApiPath = $"/{anxietySurvey.SurveyId}"
                    });
                }
            }
            return surveyListDto;
        }
    }
}
