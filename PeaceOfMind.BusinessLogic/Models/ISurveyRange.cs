namespace PeaceOfMind.Service.Models
{
    public interface ISurveyRange
    {
        int HigherIndex { get; set; }
        int LowerIndex { get; set; }
        int RangeLayerOrderId { get; set; }
        string RangeNameLayer { get; set; }
        System.Collections.Generic.IEnumerable<ISurveyRange> SubRanges { get; set; }
    }
}