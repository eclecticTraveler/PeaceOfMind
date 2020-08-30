using DataMovement.Dtos;
using PeaceOfMind.DataMovement.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataMovement.Factory
{
    public class DtoFactory
    {
        public static IAnswerDto CreateAnswerDto()
        {
            return new AnswerDto();
        }
        public static IQuestionDto CreateQuestionDto()
        {
            return new QuestionDto();
        }
        public static IQuestionOptionDto CreateQuestionOptionDto()
        {
            return new QuestionOptionDto();
        }
        //public static IResultDto CreateResultDto()
        //{
        //    return new ResultDto();
        //}
        public static ISurveyDto CreateSurveyDto()
        {
            return new SurveyDto();
        }
    }
}
