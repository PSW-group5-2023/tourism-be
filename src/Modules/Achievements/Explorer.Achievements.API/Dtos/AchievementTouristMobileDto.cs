using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Achievements.API.Dtos
{
    public class AchievementTouristMobileDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Rarity { get; set; }
        public List<int> CraftingRecipe { get; set; }
        public AchievementTouristMobileDto() { }
        public AchievementTouristMobileDto(AchievementDto achievementDto) 
        {
            this.Id= achievementDto.Id;
            this.Name= achievementDto.Name;
            this.Description= achievementDto.Description;
            this.Icon=achievementDto.Icon.ToString();
            this.CraftingRecipe = achievementDto.CraftingRecipe;
        }
    }
}
