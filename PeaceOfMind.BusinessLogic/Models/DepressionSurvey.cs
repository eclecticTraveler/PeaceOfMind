using PeaceOfMind.DataMovement.Dtos;
using PeaceOfMind.Service.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DataMovement.Dtos;
using PeaceOfMind.Service.Repositories;

namespace PeaceOfMind.Service.Models
{
    public class DepressionSurvey : Survey, ISurveyWrapper
    {
        private ISurveyRepository _repository;
        public override string SurveyName { get; set; } = "Depression";
        public override int SurveyId { get; set; } = 1;
        public DepressionSurvey()
        {
        }
        public DepressionSurvey(ISurveyRepository repository, IMapper mapper) : base(mapper, repository)
        {
            _repository =  repository;
        }

        public ISurveyResult GetSurveyResults(ISurveyResult surveyResult, IEnumerable<IAnswer> answers)
        {
            if (answers == null)
            {
                throw new System.ArgumentException("list provided is null or empty");
            }
            surveyResult.DateTaken = DateTime.UtcNow;
            surveyResult.Title = "Depression";
            surveyResult.Description = "This is were you rate this week on the scale";
            surveyResult.TotalSurveyPoints = GetSurveyPoints(answers);
            surveyResult.Ranges = GetRangesForSurveyScale();
            surveyResult.SymptomLevelDescription = GetSymptomLevelDescription(surveyResult.TotalSurveyPoints);
            return surveyResult;
        }

        public string GetSymptomLevelDescription(int totalSurveyPoints)
        {
            // Get total Results
            if (totalSurveyPoints <= 13)
            {
                return "minimo";
            }
            else if (totalSurveyPoints >= 14 && totalSurveyPoints <= 19)
            {
                return "Leve";
            }
            else if (totalSurveyPoints >= 20 && totalSurveyPoints <= 28)
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