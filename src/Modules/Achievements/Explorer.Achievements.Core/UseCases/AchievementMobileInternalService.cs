using AutoMapper;
using Explorer.Achievements.API.Internal;
using Explorer.Achievements.Core.Domain.RepositoryInterfaces;
using Explorer.Achievements.Core.Domain;
using Explorer.BuildingBlocks.Core.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using Explorer.Achievements.API.Dtos.Tourist;

namespace Explorer.Achievements.Core.UseCases
{
    public class AchievementMobileInternalService : BaseService<AchievementModuleAchievementMobileDto, Achievement>, IAchievementMobileInternalService
    {
        public IAchievementRepository _achievementRepository;
        public AchievementMobileInternalService(IMapper mapper, IAchievementRepository achievementRepository) : base(mapper)
        {
            _achievementRepository = achievementRepository;
        }

        public Result<AchievementModuleAchievementMobileDto> GetAchievementById(int id)
        {
            return MapToDto(_achievementRepository.Get(id));

        }
    }
}
