using AutoMapper;
using Explorer.Achievements.API.Dtos;
using Explorer.Achievements.API.Public;
using Explorer.Achievements.Core.Domain;
using Explorer.Achievements.Core.Domain.RepositoryInterfaces;
using Explorer.BuildingBlocks.Core.UseCases;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Achievements.Core.UseCases
{
    public class AchievementService : CrudService<AchievementDto, Achievement>, IAchievementService
    {
        public IAchievementRepository _achievementRepository;
        public AchievementService(ICrudRepository<Achievement> crudRepository, IMapper mapper, IAchievementRepository achievementRepository) : base(crudRepository, mapper)
        {
            _achievementRepository = achievementRepository;
        }
    }
}
