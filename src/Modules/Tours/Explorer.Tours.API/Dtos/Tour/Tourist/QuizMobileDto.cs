using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos.Tour.Tourist
{
    public class QuizMobileDto
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public List<TourModuleAnswerMobileDto> Answers { get; set; }

    }
}
