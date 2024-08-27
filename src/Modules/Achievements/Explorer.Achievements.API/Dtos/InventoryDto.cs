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
        public Dictionary<int,int> Achievements { get; set; }
        public InventoryDto()
        {
            Achievements = new Dictionary<int, int>();
        }
        public InventoryDto(long userId, Dictionary<int, int> achievements)
        {
            UserId = userId;
            Achievements = achievements;
        }

    }
}
