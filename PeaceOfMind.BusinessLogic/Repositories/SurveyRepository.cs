using PeaceOfMind.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeaceOfMind.Service.Repositories
{
    public class SurveyRepository
    {
        public IEnumerable<Question> GetSurveyQuestions(int surveyId)
        {
            List<Question> questions = new List<Question>();
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
            questions.Add(q1);

            return questions;
        }

        public IEnumerable<ISurveyWrapper> GetAvailableDistinctSurveys()
        {
            //return new List<Survey>
            //{
            //    new Survey
            //    {
            //     SurveyId = 1,
            //     SurveyName = "Anxiety"
            //    },
            //    new Survey
            //    {
            //     SurveyId = 2,
            //     SurveyName = "Depression"
            //    }
            //};
            return new List<ISurveyWrapper>();
        }
    }
}
