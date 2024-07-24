using Explorer.Achievements.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.API.Dtos
{
    public class QuizTouristMobileDto
    {
        public List<QuizQuestionMobileDto> Questions { get; set; }
        public AchievementMobileDto Achievement { get; set; }
    }
}
