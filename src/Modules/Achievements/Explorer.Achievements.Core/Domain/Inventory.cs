using Explorer.BuildingBlocks.Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Achievements.Core.Domain
{
    public class Inventory:Entity
    {
        public long UserId { get; private set; }
        [Column("Achievements", TypeName = "jsonb")]
        public Dictionary<int,int> Achievements { get;  set; }
        //public List<int> AchievementsId { get; set;}
        public Inventory() 
        {
            Achievements = new Dictionary<int, int>();
        }
        public Inventory(long userId, Dictionary<int, int> achievements) 
        {
            UserId = userId;
            Achievements = achievements;
        }
        public void AddAchievementToInventory(int achievementId)
        {
            if(Achievements.ContainsKey(achievementId))
                Achievements[achievementId]++;
            else
                Achievements.Add(achievementId, 1);
        }
        public void AddComplexAchievementToInventory(int achievementId, List<int> requiredAchievements)
        {
            foreach (var ra in requiredAchievements)
            {
                if (Achievements.ContainsKey((int)ra) && Achievements[ra]>0)
                    Achievements[ra]--;
            }
            AddAchievementToInventory(achievementId);
        }
    }
}
