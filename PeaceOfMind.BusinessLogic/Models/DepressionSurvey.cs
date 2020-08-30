using PeaceOfMind.DataMovement.Dtos;
using PeaceOfMind.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace PeaceOfMind.Service.Models
{
    public class DepressionSurvey : Survey, ISurveyWrapper
    {
        private IEnumerable<IAnswer> _answers;
        private MapperConfiguration _config;

        public DepressionSurvey(IEnumerable<IAnswer> answers)
        {
            _answers = answers;
        }
        public DepressionSurvey(IEnumerable<IAnswerDto> answersDtos)
        {
            _config = new MapperConfiguration(cfg =>
            cfg.CreateMap<IAnswerDto, IAnswer>()
            );
            
            _answers = TransformDtoToModel(answersDtos);
            this.SurveyId = 1;
            this.SurveyName = "Depression";
        }
        public IEnumerable<ISurveyRange> GetRangesForSurveyScale()
        {
            throw new NotImplementedException();
        }

        public ISurveyResult GetSurveyResults()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<IAnswer> 
            TransformDtoToModel(IEnumerable<IAnswerDto> answersDtos)
        {
            // lets use automapper for this
            var mapper = new Mapper(_config);
            IEnumerable<IAnswer> answers = mapper.Map<IEnumerable<IAnswerDto>,
                IEnumerable<IAnswer>>(answersDtos);
            return answers;
        }

        public override bool VerifySurveyCompletion()
        {
            throw new NotImplementedException();
        }
    }
}
