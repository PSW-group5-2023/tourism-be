using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Core.Domain;
using Explorer.Encounters.Core.Domain.RepositoryInterfaces;
using FluentResults;

namespace Explorer.Encounters.Core.UseCases
{
    public class ChallengeExecutionService : CrudService<ChallengeExecutionDto, ChallengeExecution>, IChallengeExecutionService
    {
        private readonly IChallengeExecutionRepository _challengeExecutionRepository;
        public ChallengeExecutionService(IChallengeExecutionRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _challengeExecutionRepository = repository;
        }

        public Result<ChallengeExecutionDto> Complete(long challengeId, long touristId)
        {
            try
            {
                var challengeExecution = _challengeExecutionRepository.GetByChallengeIdAndTouristId(challengeId, touristId);
                challengeExecution.CompleteSocial(_challengeExecutionRepository.GetNumberOfTouristsByChallengeId(challengeExecution.Challenge.Id));
                _challengeExecutionRepository.SaveChanges();
                return MapToDto(challengeExecution);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }

        public Result<PagedResult<ChallengeExecutionDto>> GetPagedByKeyPointIds(List<long> keyPointIds, int page, int pageSize)
        {
            var result = _challengeExecutionRepository.GetPagedByKeyPointIds(keyPointIds, page, pageSize);
            return MapToDto(result);
        }

        public Result<PagedResult<ChallengeExecutionDto>> GetPagedByTouristId(long touristId, int page, int pageSize)
        {
            var result = _challengeExecutionRepository.GetPagedByTouristId(touristId, page, pageSize);
            return MapToDto(result);
        }
    }
}
