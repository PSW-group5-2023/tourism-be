using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.API.Dtos
{
    public class QuizQuestionMobileDto
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public List<AnswerMobileDto> Answers { get; set; }
        public QuizQuestionMobileDto() { }
        public QuizQuestionMobileDto(QuestionDto questionDto)
        {
            this.QuestionId = questionDto.Id;
            this.Question = questionDto.Content;
            this.Answers = new List<AnswerMobileDto>();
            foreach (var answer in questionDto.Answers)
            {
                AnswerMobileDto answerTouristDto = new AnswerMobileDto(answer);
                answerTouristDto.QuestionId=this.QuestionId;
                this.Answers.Add(answerTouristDto);
            }
        }
    }
}
