using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.API.Dtos.Tourist
{
    public class EncounterModuleQuizMobileDto
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public List<EncounterModuleAnswerMobileDto> Answers { get; set; }
        public EncounterModuleQuizMobileDto() { }
        public EncounterModuleQuizMobileDto(QuestionDto questionDto)
        {
            QuestionId = questionDto.Id;
            Question = questionDto.Content;
            Answers = new List<EncounterModuleAnswerMobileDto>();
            foreach (var answer in questionDto.Answers)
            {
                EncounterModuleAnswerMobileDto answerTouristDto = new EncounterModuleAnswerMobileDto(answer);
                answerTouristDto.QuestionId = QuestionId;
                Answers.Add(answerTouristDto);
            }
        }
    }
}
