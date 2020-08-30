using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeaceOfMind.Service.Models
{
    public class QuestionOption : IQuestionOption
    {
        public string Option { get; set; }
        public int OptionScaleValue { get; set; }
    }
}
