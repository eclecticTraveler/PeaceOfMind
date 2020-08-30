using DataMovement.Dtos;
using PeaceOfMind.DataMovement.Dtos;
using PeaceOfMind.Service.BusinessOfLogic;
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
            List<ISurveyDto> surveysDtos = new List<ISurveyDto>();
            // Pull from Database
            SurveyRepository repo = new SurveyRepository();
            var surveys = repo.GetAvailableDistinctSurveys();

            // TODO: use mapper library
            foreach (var survey in surveys)
            {
                surveysDtos.Add(
                                        //new SurveyDto
                                        //{
                                        //    SurveyId = survey.SurveyId,
                                        //    SurveyName = survey.SurveyName
                                        //}
                                        new SurveyDto()
                    );
            }

            //Return
            return surveysDtos;
        }

        public ISurveyResultDto ProcessSurveyAnswers(int surveyId, IEnumerable<IAnswerDto> answerDtos)
        {
            // Here is where threads are nice to save to the DB answers while processing takes place
            if (answerDtos == null)
            {

            }

            //
            var survey = ServiceFactory.GetSurveySpecific(surveyId, answerDtos);

            SurveyProcessor processor = new SurveyProcessor();
            SurveyResult surveyResult = processor.GetSurveyResults(surveyId, answerDtos);
            // Validate

            //Save in DB only if authenticated

            //Map

            // Return
            throw new NotImplementedException();
        }

        public IEnumerable<IQuestionDto> FetchSurveyQuestions(int surveyId)
        {
            List<QuestionDto> questionsDtos = new List<QuestionDto>();
            // Pull from Database
            SurveyRepository repo = new SurveyRepository();
            var questions = repo.GetSurveyQuestions(surveyId);

            // TODO: use mapper library
            foreach (var question in questions)
            {
                questionsDtos.Add(
                    new QuestionDto
                    {
                        QuestionNumber = question.QuestionNumber,
                        WordedQuestion = question.WordedQuestion,
                        WordedOptions = question.CovertQuestionOptionToDto()
                    }
                    );
            }
            return questionsDtos;
        }
    }
}
