using Explorer.Achievements.API.Dtos;
using Explorer.BuildingBlocks.Core.UseCases;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Achievements.Core.Domain.RepositoryInterfaces
{
    public interface IAchievementRepository
    {
        List<Achievement> GetAllBaseAchievements();
        List<Achievement> GetAllComplexAchievements();
    }
}
