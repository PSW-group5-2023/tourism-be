using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.Domain
{
    public class GuestUser : Entity
    {
        public string Username { get; private set; }
        public List<int> AchievementsId { get; set; }
        public Status Status { get; private set; }

        public GuestUser() 
        {
            AchievementsId = new List<int>();
        }
    }

    public enum Status
    {
        Activated,
        NotActivated
    }
}
