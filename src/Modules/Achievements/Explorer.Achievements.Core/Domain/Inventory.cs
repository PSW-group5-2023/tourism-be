using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Achievements.Core.Domain
{
    public class Inventory:Entity
    {
        public long UserId { get; private set; }
        public List<int> AchievementsId { get; set;}
        public Inventory() 
        {
            AchievementsId = new List<int>();
        }
        public Inventory(long userId, List<int> achievements) 
        {
            UserId = userId;
            AchievementsId = achievements;
        }
        public void AddAchievementToInventory(int achievementId)
        {
            if(!AchievementsId.Contains(achievementId))
                AchievementsId.Add(achievementId);
        }
    }
}
