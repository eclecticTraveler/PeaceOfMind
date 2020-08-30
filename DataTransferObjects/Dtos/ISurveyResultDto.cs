using System;
using System.Collections.Generic;

namespace DataMovement.Dtos
{
    public interface ISurveyResultDto
    {
        int TotalSurveyPoints { get; set; }
        DateTime DateTaken { get; set; }
        string Description { get; set; }
        string Title { get; set; }
        string SymptomLevelDescription { get; set; }
        IEnumerable<ISurveyRangeDto> Ranges { get; set; }
    }
}