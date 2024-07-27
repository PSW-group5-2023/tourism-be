using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos.Tour.Tourist
{
    public class TourModuleAnswerMobileDto
    {
        public int QuestionId { get; set; }
        public string Answer { get; set; }
        public bool IsTrue { get; set; }

    }
}
