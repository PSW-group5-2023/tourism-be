using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Core.Domain;
using Explorer.Encounters.Core.Domain.RepositoryInterfaces;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Encounters.Core.UseCases
{
    public class EncounterService : CrudService<EncounterDto, Encounter>, IEncounterService
    {
        private readonly IEncounterRepository _encounterRepository;
        private readonly IUserExperienceService _userExperienceService;
        private readonly IEncounterExecutionService _encounterExecutionService;
        public EncounterService(IEncounterRepository encounterRepository, IMapper mapper, IUserExperienceService userExperienceService, IEncounterExecutionService encounterExecutionService) : base(encounterRepository, mapper)
        {
            _encounterRepository = encounterRepository;
            _userExperienceService = userExperienceService;
            _encounterExecutionService = encounterExecutionService;
        }

        public Result<EncounterDto> CreateForTourist(EncounterDto encounterDto, long touristId)
        {
            try
            {
                var userXp = _userExperienceService.GetByUserId(touristId);
                if (userXp.IsFailed || userXp.Value.Level < 10) throw new ArgumentException($"User needs level 10 to create an encounter. Current level: {userXp.ValueOrDefault.Level}");
                var result = _encounterRepository.Create(MapToDomain(encounterDto));
                return MapToDto(result);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }

        public Result<EncounterDto> DeleteForTourist(long id, long touristId)
        {
            try
            {
                var encounter = _encounterRepository.Get(id);
                if (touristId != encounter.CreatorId) throw new ArgumentException("User isn't the owner of the encounter");
                _encounterRepository.Delete(id);
                return Result.Ok();
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }

        public Result<PagedResult<EncounterDto>> GetPagedByKeyPointIdsForTourist(List<long> keyPointIds, int page, int pageSize, long touristId)
        {
            var result = _encounterRepository.GetPagedByKeyPointIds(keyPointIds, page, pageSize);
            var filteredList = result.Results.Where(e =>
            {
                var encounterExecution = _encounterExecutionService.GetByTouristIdAndEnctounterId(touristId, e.Id);
                return encounterExecution.IsFailed || encounterExecution.Value.CompletionTime is null;
            });
            var filteredResults = new PagedResult<Encounter>(filteredList.ToList(), filteredList.Count());
            return MapToDto(result);
        }

        public Result<PagedResult<EncounterDto>> GetPublicPagedForTourist(long touristId, int page, int pageSize)
        {
            var result = _encounterRepository.GetPublicPaged(page, pageSize);
            var filteredList = result.Results.Where(e =>
            {
                var encounterExecution = _encounterExecutionService.GetByTouristIdAndEnctounterId(touristId, e.Id);
                return encounterExecution.IsFailed || encounterExecution.Value.CompletionTime is null;
            });
            var filteredResults = new PagedResult<Encounter>(filteredList.ToList(), filteredList.Count());
            return MapToDto(result);
        }

        public Result<EncounterDto> UpdateForTourist(EncounterDto encounterDto, long touristId)
        {
            try
            {
                var encounter = _encounterRepository.Get(encounterDto.Id);
                if (touristId != encounter.CreatorId) throw new ArgumentException("User isn't the owner of the encounter");
                var result = _encounterRepository.Update(MapToDomain(encounterDto));
                return MapToDto(result);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
            catch (DbUpdateException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }
    }
}
