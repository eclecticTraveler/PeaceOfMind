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
        public List<QuestionOption> WordedOptions { get; set; }

        //TODO: Fix this so that it mapps with automapper on the right place
        public List<QuestionOptionDto> CovertQuestionOptionToDto()
        {
            List<QuestionOptionDto> questionOptionDtos = new List<QuestionOptionDto>();
            foreach (var wordedOption in WordedOptions)
            {
                questionOptionDtos.Add(
                    new QuestionOptionDto
                    {
                        Option = wordedOption.Option,
                        OptionScaleValue = wordedOption.OptionScaleValue
                    }
                    );
            }

            return questionOptionDtos;
        }
    }
}
