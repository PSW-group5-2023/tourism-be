using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Achievements.API.Dtos
{
    public class AchievementDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Uri Icon { get; set; }
        public int Rarity { get; set; }  
        public List<int> CraftingRecipe { get; set; }
    }
}
