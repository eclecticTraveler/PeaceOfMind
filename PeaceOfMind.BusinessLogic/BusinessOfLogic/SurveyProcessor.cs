using System;
using System.Collections.Generic;
using System.Text;
using PeaceOfMind.DataMovement.Dtos;
using PeaceOfMind.Service.Models;

namespace PeaceOfMind.Service.BusinessOfLogic
{
    public class SurveyProcessor
    {
        public SurveyResult GetSurveyResults(int surveyId, IEnumerable<IAnswerDto> answerDtos)
        {

            SurveyResult surveyResult = new SurveyResult();
            List<SurveyRange> surveyRanges = new List<SurveyRange>();
            int totalSurveyPoints = 0;
            // Process total point answers
            foreach (var answer in answerDtos)
            {
                totalSurveyPoints += answer.AnswerScaleValue;
            }
            // Distinguish what kind of survey we are dealing with
            if (surveyId == 1)// Depression
            {

                surveyResult.TotalSurveyPoints = totalSurveyPoints;
                surveyResult.DateTaken = DateTime.UtcNow;
                surveyResult.Title = "Depression";
                surveyResult.Description = "This is were you rate this week on the scale";

                if (totalSurveyPoints <= 13){
                    surveyResult.SymptomLevelDescription = "minimo";
                }
                else if (totalSurveyPoints >= 14 && totalSurveyPoints <= 19){
                    surveyResult.SymptomLevelDescription = "Leve";
                }
                else if (totalSurveyPoints >= 20 && totalSurveyPoints <= 28){
                    surveyResult.SymptomLevelDescription = "Moderado";
                }
                else{
                    surveyResult.SymptomLevelDescription = "Grave";
                }

                // Get Ranges
                surveyRanges.Add(new SurveyRange
                {
                    LowerIndex = 00,
                    HigherIndex = 13,
                    RangeLayerOrderId = 1,
                    RangeNameLayer = "Minimo"
                });
                surveyRanges.Add(new SurveyRange
                {
                    LowerIndex = 14,
                    HigherIndex = 19,
                    RangeLayerOrderId = 2,
                    RangeNameLayer = "Leve"
                });
                surveyRanges.Add(new SurveyRange
                {
                    LowerIndex = 20,
                    HigherIndex = 28,
                    RangeLayerOrderId = 3,
                    RangeNameLayer = "Moderado"
                });
                surveyRanges.Add(new SurveyRange
                {
                    LowerIndex = 29,
                    HigherIndex = 63,
                    RangeLayerOrderId = 4,
                    RangeNameLayer = "Grave"
                });

                surveyResult.Ranges = surveyRanges;

            }
            else if (surveyId == 2)//Anxiety
            {

            }
            else
            {

            }
            return surveyResult;

        }
    }
}
