using PeaceOfMind.DataMovement.Dtos;
using PeaceOfMind.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeaceOfMind.Service.Models
{
    public class AnxietySurvey : Survey, ISurveyWrapper
    {
        private IEnumerable<IAnswer> _answers;

        public AnxietySurvey(IEnumerable<IAnswer> answers)
        {
            _answers = answers;
        }
        public AnxietySurvey(IEnumerable<IAnswerDto> answersDtos)
        {
            _answers = TransformDtoToModel(answersDtos);
        }

        public IEnumerable<ISurveyRange> GetRangesForSurveyScale()
        {
            throw new NotImplementedException();
        }

        public ISurveyResult GetSurveyResults()
        {
            throw new NotImplementedException();
        }

        public override bool VerifySurveyCompletion()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<IAnswer> TransformDtoToModel(IEnumerable<IAnswerDto> answersDtos)
        {
            throw new NotImplementedException();
        }
    }
}
