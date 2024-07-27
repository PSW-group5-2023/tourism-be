using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Achievements.API.Dtos.Tourist
{
    public class AchievementModuleAchievementMobileDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Rarity { get; set; }
        public List<int> CraftingRecipe { get; set; }
        public AchievementModuleAchievementMobileDto() { }
        public AchievementModuleAchievementMobileDto(AchievementDto achievementDto)
        {
            Id = achievementDto.Id;
            Name = achievementDto.Name;
            Description = achievementDto.Description;
            Icon = achievementDto.Icon.ToString();
            CraftingRecipe = achievementDto.CraftingRecipe;
        }
    }
}
