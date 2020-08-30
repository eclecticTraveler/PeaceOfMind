namespace PeaceOfMind.DataMovement.Dtos
{
    public class QuestionOptionDto : IQuestionOptionDto
    {
        public string Option { get; set; }
        public int OptionScaleValue { get; set; }
    }
}