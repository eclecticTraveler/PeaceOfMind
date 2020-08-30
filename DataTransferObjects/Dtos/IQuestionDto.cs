using System.Collections.Generic;

namespace PeaceOfMind.DataMovement.Dtos
{
    public interface IQuestionDto
    {
        int QuestionNumber { get; set; }
        IEnumerable<IQuestionOptionDto> WordedOptions { get; set; }
        string WordedQuestion { get; set; }
    }
}