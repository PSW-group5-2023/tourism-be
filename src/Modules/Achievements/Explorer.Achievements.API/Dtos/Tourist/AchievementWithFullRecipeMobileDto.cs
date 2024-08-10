using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Achievements.API.Dtos.Tourist
{
    public class AchievementWithFullRecipeMobileDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Rarity { get; set; }
        public List<AchievementModuleAchievementMobileDto> CraftingRecipe { get; set; }
    }
}
