using System.Collections.Generic;

namespace DataMovement.Dtos
{
    public interface ISurveyRangeDto
    {
        int HigherIndex { get; set; }
        int LowerIndex { get; set; }
        int RangeLayerOrderId { get; set; }
        string RangeNameLayer { get; set; }
        IEnumerable<SurveyRangeDto> SubRanges { get; set; }
    }
}