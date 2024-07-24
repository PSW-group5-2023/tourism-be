using Explorer.Achievements.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Achievements.API.Internal
{
    public interface IAchievementTouristInternalService
    {
        public Result<AchievementTouristMobileDto> GetAchievementById(int id);
    }
}
