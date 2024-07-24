using AutoMapper;
using Explorer.Achievements.API.Dtos;
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

namespace Explorer.Achievements.Core.UseCases
{
    public class AchievementTouristInternalService : BaseService<AchievementTouristMobileDto, Achievement>, IAchievementTouristInternalService
    {
        public IAchievementRepository _achievementRepository;
        public AchievementTouristInternalService(IMapper mapper, IAchievementRepository achievementRepository) : base(mapper)
        {
            _achievementRepository = achievementRepository;
        }

        public Result<AchievementTouristMobileDto> GetAchievementById(int id)
        {
            return MapToDto(_achievementRepository.Get(id));

        }
    }
}
