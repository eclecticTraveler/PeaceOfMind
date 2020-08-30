using PeaceOfMind.Service.Factory;
using PeaceOfMind.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeaceOfMind.Service.Repositories
{
    public class SurveyRepository : ISurveyRepository
    {
        public IEnumerable<IQuestion> GetSurveyQuestions(int surveyId, IEnumerable<IQuestion> questions)
        {
            var questionList = questions.ToList();
            Question q1 = new Question
            {
                WordedOptions = new List<QuestionOption>
                {
                     new QuestionOption() { Option = "Não me sinto triste", OptionScaleValue = 0 },
                     new QuestionOption() { Option = "Eu me sinto triste", OptionScaleValue = 1 },
                     new QuestionOption() { Option = "Estou sempre triste e não consigo sair disto", OptionScaleValue = 2 },
                     new QuestionOption() { Option = "Estou tão triste ou infeliz que não consigo suportar", OptionScaleValue = 3 }
                }
            };
            questionList.Add(q1);

            return questionList;
        }

        public IEnumerable<ISurvey> GetAvailableDistinctSurveys()
        {
            //TODO GET SURVEYS AVAILABLE FROM DB
            var surveys = new List<ISurvey>
            {
                new DepressionSurvey(),
                new AnxietySurvey()
            };
            return surveys;
        }

        public void SaveSurveyResult(ISurveyResult surveyResult)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ISurveyResult> GetSurveyResultsPerPeriod(DateTime minDate, DateTime maxDate)
        {
            throw new NotImplementedException();
        }
    }
}
