using System.Collections.Generic;

namespace DataMovement.Dtos
{
    public class SurveyRangeDto : ISurveyRangeDto
    {
        public int LowerIndex { get; set; }
        public int HigherIndex { get; set; }
        public string RangeNameLayer { get; set; }
        public int RangeLayerOrderId { get; set; }
        public IEnumerable<SurveyRangeDto> SubRanges { get; set; }
    }
}