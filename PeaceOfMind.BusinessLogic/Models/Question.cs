using PeaceOfMind.DataMovement.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeaceOfMind.Service.Models
{
    public class Question : IQuestion
    {
        public int QuestionNumber { get; set; }
        public bool IsQuestionCompleted { get; set; } = false;
        public DateTime QuestionCompletedOn { get; set; }
        public string WordedQuestion { get; set; }
        public IEnumerable<IQuestionOption> WordedOptions { get; set; }
    }
}
