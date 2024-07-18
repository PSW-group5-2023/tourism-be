using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Achievements.API.Dtos
{
    public class InventoryDto
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public List<int> AchievementsId { get; set; }
        public InventoryDto()
        {
            AchievementsId = new List<int>();
        }
        public InventoryDto(long userId, List<int> achievements)
        {
            UserId = userId;
            AchievementsId = achievements;
        }

    }
}
