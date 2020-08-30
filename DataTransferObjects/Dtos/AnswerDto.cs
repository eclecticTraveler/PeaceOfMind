using System;
using System.Collections.Generic;
using System.Text;

namespace PeaceOfMind.DataMovement.Dtos
{
    public class AnswerDto : IAnswerDto
    {
        public int QuestionNumber { get; set; }
        public int AnswerScaleValue { get; set; }
    }
}
