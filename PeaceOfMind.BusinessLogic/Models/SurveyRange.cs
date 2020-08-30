using System;
using System.Collections.Generic;
using System.Text;

namespace PeaceOfMind.Service.Models
{
    public class SurveyRange : ISurveyRange
    {
        public int LowerIndex { get; set; }
        public int HigherIndex { get; set; }
        public string RangeNameLayer { get; set; }
        public int RangeLayerOrderId { get; set; }
        public IEnumerable<ISurveyRange> SubRanges { get; set; }
    }
}
