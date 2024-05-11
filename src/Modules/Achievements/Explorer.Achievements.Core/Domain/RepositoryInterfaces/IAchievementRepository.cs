using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Achievements.Core.Domain.RepositoryInterfaces
{
    public interface IAchievementRepository
    {
        Achievement GetAchievementByKeypointId(int keypointId);
    }
}
