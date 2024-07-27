using Explorer.Achievements.API.Dtos.Tourist;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Achievements.API.Internal
{
    public interface IAchievementMobileInternalService
    {
        public Result<AchievementModuleAchievementMobileDto> GetAchievementById(int id);
    }
}
