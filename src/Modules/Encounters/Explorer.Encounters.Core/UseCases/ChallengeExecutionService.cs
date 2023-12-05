using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Core.Domain;

namespace Explorer.Encounters.Core.UseCases
{
    public class ChallengeExecutionService : CrudService<ChallengeExecutionDto, ChallengeExecution>, IChallengeExecutionService
    {
        public ChallengeExecutionService(ICrudRepository<ChallengeExecution> crudRepository, IMapper mapper) : base(crudRepository, mapper)
        {
        }
    }
}
