using Explorer.Achievements.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.API.Dtos.Tourist
{
    public class EncounterModuleQuizAchievementMobileDto
    {
        public List<EncounterModuleQuizMobileDto> Questions { get; set; }
        public EncounterModuleAchievementMobileDto? Achievement { get; set; }
    }
}
