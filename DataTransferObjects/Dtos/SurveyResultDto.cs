using System;
using System.Collections.Generic;
using System.Text;

namespace DataMovement.Dtos
{
    public class SurveyResultDto : ISurveyResultDto
    {
        public int TotalSurveyPoints { get; set; }
        public DateTime DateTaken { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string SymptomLevelDescription { get; set; }
        public IEnumerable<ISurveyRangeDto> Ranges { get; set; }
    }
}
