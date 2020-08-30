using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeaceOfMind.DataMovement.Dtos
{
    public class SurveyDto : ISurveyDto
    {
        public int SurveyId { get; set; }
        public string SurveyName { get; set; }
        public string SurveyApiPath { get; set; }
    }
}
