namespace PeaceOfMind.Service.Models
{
    public interface IQuestionOption
    {
        string Option { get; set; }
        int OptionScaleValue { get; set; }
    }
}