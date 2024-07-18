using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.API.Dtos
{
    public class SubmittedAnswerDto
    {
        public string Content { get; set; }
        public uint OrderInQuiz { get; set; }
    }
}
