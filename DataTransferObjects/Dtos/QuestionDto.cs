using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeaceOfMind.DataMovement.Dtos
{
    public class QuestionDto : IQuestionDto
    {
        public int QuestionNumber { get; set; }
        public string WordedQuestion { get; set; }
        public IEnumerable<IQuestionOptionDto> WordedOptions { get; set; }
    }
}
