using AutoMapper;
using DataMovement.Dtos;
using PeaceOfMind.DataMovement.Dtos;
using PeaceOfMind.Service.Models;
using PeaceOfMind.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeaceOfMind.Service.Models
{
    public class AnxietySurvey : Survey, ISurveyWrapper
    {
        private ISurveyRepository _repository;
        public override string SurveyName { get; set; } = "Anxiety";
        public override int SurveyId { get; set; } = 2;

        public AnxietySurvey()
        { 
        }
        public AnxietySurvey(ISurveyRepository repository, IMapper mapper) : base(mapper, repository)
        {
            _repository = repository;
        }

        public ISurveyResult GetSurveyResults(ISurveyResult surveyResult, IEnumerable<IAnswer> answers)
        {
            if (answers == null)
            {
                throw new System.ArgumentException("list provided is null or empty");
            }
            surveyResult.DateTaken = DateTime.UtcNow;
            surveyResult.Title = "Anxiety";
            surveyResult.Description = "This is were you rate this week on the scale";
            surveyResult.TotalSurveyPoints = GetSurveyPoints(answers);
            surveyResult.Ranges = GetRangesForSurveyScale();
            surveyResult.SymptomLevelDescription = GetSymptomLevelDescription(surveyResult.TotalSurveyPoints);
            return surveyResult;
        }

        public string GetSymptomLevelDescription(int totalSurveyPoints)
        {
            // Get total Results
            if (totalSurveyPoints <= 20)
            {
                return "minimo";
            }
            else if (totalSurveyPoints >= 21 && totalSurveyPoints <= 29)
            {
                return "Leve";
            }
            else if (totalSurveyPoints >= 30  && totalSurveyPoints <= 31)
            {
                return "Moderado";
            }
            else
            {
                return "Grave";
            }
        }
        public IEnumerable<ISurveyRange> GetRangesForSurveyScale()
        {
            return new List<ISurveyRange>
            {
               // Get Ranges
               new SurveyRange
                {
                    LowerIndex = 00,
                    HigherIndex = 13,
                    RangeLayerOrderId = 1,
                    RangeNameLayer = "Minimo"
                },
               new SurveyRange
                {
                    LowerIndex = 14,
                    HigherIndex = 19,
                    RangeLayerOrderId = 2,
                    RangeNameLayer = "Leve"
                },
                new SurveyRange
                {
                    LowerIndex = 20,
                    HigherIndex = 28,
                    RangeLayerOrderId = 3,
                    RangeNameLayer = "Moderado"
                },
                new SurveyRange
                {
                    LowerIndex = 29,
                    HigherIndex = 63,
                    RangeLayerOrderId = 4,
                    RangeNameLayer = "Grave"
                }
            };
        }
    }
}
