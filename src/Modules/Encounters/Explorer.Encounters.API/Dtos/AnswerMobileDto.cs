using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.API.Dtos
{
    public class AnswerMobileDto
    {
        public AnswerMobileDto()
        {
        }
        public AnswerMobileDto(AnswerDto answerDto)
        {
            this.Answer = answerDto.Content;
            this.IsTrue = answerDto.Correct;
        }
        public int QuestionId { get; set; }
        public string Answer { get; set; }
        public bool IsTrue { get; set; }

    }
}
