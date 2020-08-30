using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataMovement.Dtos;
using PeaceOfMind.DataMovement.Dtos;
using PeaceOfMind.Service.Repositories;

namespace PeaceOfMind.Service.Models
{
    public class Survey : ISurvey
    {

        private IMapper _mapper;

        private ISurveyRepository _repository;
        public virtual string SurveyName { get; set; }
        public virtual int SurveyId { get; set; }
        public DateTime DateCompleted { get; set; }
        public bool IsSurveyCompleted { get; set ; }
        public bool IsSurveyStarted { get; set; }
        public int LastQuestionCompleted { get; private set; } = -1;
        public IEnumerable<IQuestion> Questions { get; set; }
        public int TotalNumOfQuestions { get; }
        public int TotalAvailablePoints { get; }
        public int UserTotalPoints { get; }

        public Survey()
        { 
        }
        public Survey(IMapper mapper, ISurveyRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public int GetSurveyPoints(IEnumerable<IAnswer> answers)
        {
            int totalSurveyPoints = 0;
            foreach (var answer in answers)
            {
                totalSurveyPoints += answer.AnswerScaleValue;
            }
            return totalSurveyPoints;
        }
        public IEnumerable<IQuestion> GetSurveyQuestions(int surveyId, IEnumerable<IQuestion> questions)
        {
            return _repository.GetSurveyQuestions(surveyId, questions);
        }
        public bool VerifySurveyCompletion(IEnumerable<IQuestion> questions)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<IAnswer> TransformAnswersDtoToModel(IEnumerable<IAnswerDto> answersDtos)
        {
            return _mapper.Map<IEnumerable<IAnswerDto>, IEnumerable<IAnswer>>(answersDtos);
        }

        public IEnumerable<IAnswerDto> TransformAnswersModelToDto(IEnumerable<IAnswer> answers)
        {
            return _mapper.Map<IEnumerable<IAnswer>, IEnumerable<IAnswerDto>>(answers);
        }

        public IEnumerable<IQuestion> TransformQuestionsDtoToModel(IEnumerable<IQuestionDto> questionsDto)
        {
            return _mapper.Map<IEnumerable<IQuestionDto>, IEnumerable<IQuestion>>(questionsDto);
        }

        public IEnumerable<IQuestionDto> TransformQuestionsModelToDto(IEnumerable<IQuestion> questions)
        {
            return _mapper.Map<IEnumerable<IQuestion>, IEnumerable<IQuestionDto>>(questions);
        }

        public ISurveyResult TransformSurveyResultDtoToModel(ISurveyResultDto surveyResultDto)
        {
            return _mapper.Map<ISurveyResultDto, ISurveyResult>(surveyResultDto);
        }

        public ISurveyResultDto TransformSurveyResultModelToDto(ISurveyResult surveyResult)
        {
            return _mapper.Map<ISurveyResult, ISurveyResultDto>(surveyResult);
        }
    }
}
