using Explorer.Achievements.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Achievements.API.Public
{
    public interface IAchievementService
    {
        Result<AchievementDto> Create(AchievementDto achievement);
        Result Delete(int id);
        Result<AchievementDto> Get(int id);
    }
}
