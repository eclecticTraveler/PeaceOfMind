using System;
using System.Collections.Generic;
using System.Text;

namespace PeaceOfMind.Service.Models
{
    public class Answer : IAnswer
    {
        public int QuestionNumber { get; set; }
        public int AnswerScaleValue { get; set; }
        public DateTime AnswerTimestap { get; set; }
    }
}
