using AutoMapper;
using DataMovement.Dtos;
using PeaceOfMind.DataMovement.Dtos;
using PeaceOfMind.Service.Models;
using PeaceOfMind.Service.Repositories;
using System;
using System.Collections.Generic;

namespace PeaceOfMind.Service.Factory
{
    public class ServiceFactory
    {
        private static MapperConfiguration CreateMapperConfig()
        {
            return new MapperConfiguration(cfg => {
                cfg.CreateMap<IAnswerDto, IAnswer>().ReverseMap();
                cfg.CreateMap<IQuestionDto, IQuestion>().ReverseMap();
                cfg.CreateMap<ISurveyResultDto, ISurveyResult>().ReverseMap();
                cfg.CreateMap<IQuestionDto, IQuestion>().ReverseMap();
                cfg.CreateMap<IQuestionOptionDto, IQuestionOption>().ReverseMap();
                cfg.CreateMap<ISurveyRangeDto, ISurveyRange>().ReverseMap();
                //cfg.CreateMap<ISurveyDto, ISurvey>();
                cfg.CreateMap<ISurveyDerived, ISurveyDto>();
                    //.IncludeBase<ISurvey, ISurveyDto>();

            });
        }
        public static ISurveyWrapper GetSurveySpecific(int surveyId, IMapper mapper, ISurveyRepository repository)
        {
            switch (surveyId)
            {
                case 1:
                    return new DepressionSurvey(repository, mapper);
                case 2:
                    return new AnxietySurvey(repository, mapper);
                default:
                    throw new System.ArgumentException("survey Id is not valid");
            }
        }

        public static ISurveyResult CreateSurveyResult()
        {
            return new SurveyResult();
        }

        public static ISurveyRepository CreateSurveyRepo()
        {
            return new SurveyRepository();
        }
       
        public static IMapper CreateMapper()
        {
            return new Mapper(CreateMapperConfig());
        }

        public static IEnumerable<ISurveyDto> CreateSurveyListDto()
        {
            return new List<SurveyDto>();
        }
    }
}
