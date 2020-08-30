using System;
using System.Collections.Generic;

namespace PeaceOfMind.Service.Models
{
    public interface ISurveyResult
    {
        DateTime DateTaken { get; set; }
        string Description { get; set; }
        IEnumerable<ISurveyRange> Ranges { get; set; }
        string SymptomLevelDescription { get; set; }
        string Title { get; set; }
        int TotalSurveyPoints { get; set; }
    }
}