using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.API.Dtos.Tourist
{
    public class EncounterModuleAnswerMobileDto
    {
        public EncounterModuleAnswerMobileDto()
        {
        }
        public EncounterModuleAnswerMobileDto(AnswerDto answerDto)
        {
            Answer = answerDto.Content;
            IsTrue = answerDto.Correct;
        }
        public int QuestionId { get; set; }
        public string Answer { get; set; }
        public bool IsTrue { get; set; }

    }
}
