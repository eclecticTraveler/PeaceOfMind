using System;
using System.Collections.Generic;
using System.Text;

namespace PeaceOfMind.Service.Models
{
    public class SurveyResult : ISurveyResult
    {
        public int TotalSurveyPoints { get; set; }
        public DateTime DateTaken { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string SymptomLevelDescription { get; set; }
        public IEnumerable<ISurveyRange> Ranges { get; set; }
    }
}
