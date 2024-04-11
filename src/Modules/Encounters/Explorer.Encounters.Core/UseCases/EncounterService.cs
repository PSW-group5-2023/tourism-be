using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Core.Domain;
using Explorer.Encounters.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.API.Dtos.Tour;
using Explorer.Tours.API.Internal;
using Explorer.Tours.Core.UseCases.Tours;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Encounters.Core.UseCases
{
    public class EncounterService : CrudService<EncounterDto, Encounter>, IEncounterService
    {
        private readonly IEncounterRepository _encounterRepository;
        private readonly IUserExperienceService _userExperienceService;
        private readonly IEncounterExecutionService _encounterExecutionService;
        private readonly IMapper _mapper;
        private readonly IInternalKeyPointService _internalKeyPointService;

        public EncounterService(IEncounterRepository encounterRepository, IMapper mapper, IUserExperienceService userExperienceService, IEncounterExecutionService encounterExecutionService, IInternalKeyPointService internalKeyPointService) : base(encounterRepository, mapper)
        {
            _encounterRepository = encounterRepository;
            _userExperienceService = userExperienceService;
            _encounterExecutionService = encounterExecutionService;
            _mapper = mapper;
            _internalKeyPointService = internalKeyPointService;
        }


        public override Result<EncounterDto> Create(EncounterDto encounterDto)
        {
            try
            {
                encounterDto.Status = 1; //Setting status on ACTIVE no matter what came from controller
                
                if(encounterDto.KeyPointId != null)
                {
                    if(!CheckKeypointAuthor(encounterDto.CreatorId, (long)encounterDto.KeyPointId)) throw new ArgumentException("This author is not the author of selected KeyPoint.");
                    TourKeyPointDto tourKeyPointDto = _internalKeyPointService.Get((long)encounterDto.KeyPointId).Value;
                    encounterDto.Longitude = tourKeyPointDto.Longitude;
                    encounterDto.Latitude = tourKeyPointDto.Latitude;
                }

                Encounter temp;
                if (encounterDto.Type == 0)
                {
                    temp = _mapper.Map<SocialEncounter>(encounterDto);
                }
                else if (encounterDto.Type == 1)
                {
                    temp = _mapper.Map<LocationEncounter>(encounterDto);
                }
                else
                {
                    temp = _mapper.Map<Encounter>(encounterDto);
                }

                var result = _encounterRepository.Create(temp);
                return MapToDto(result);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }

        private bool CheckKeypointAuthor(long authorId, long keypointId)
        {
            return _internalKeyPointService.CheckIfUserIsAuthor(authorId, keypointId).Value;
        }

        public Result<EncounterDto> CreateForTourist(EncounterDto encounterDto, long touristId)
        {
            try
            {
                var userXp = _userExperienceService.GetByUserId(touristId);
                if (userXp.IsFailed || userXp.Value.Level < 10) throw new ArgumentException($"User needs level 10 to create an encounter. Current level: {userXp.ValueOrDefault.Level}");
                encounterDto.Status = 0; // DRAFT status, dto cuva integer.
                if (encounterDto.KeyPointId != null) throw new ArgumentException("Tourist is not allowed to add encounter to a keypoint.");

                Encounter temp;
                if (encounterDto.Type == 0)
                {
                    temp = _mapper.Map<SocialEncounter>(encounterDto);
                }
                else if (encounterDto.Type == 1)
                {
                    temp = _mapper.Map<LocationEncounter>(encounterDto);
                }
                else
                {
                    temp = _mapper.Map<Encounter>(encounterDto);
                }

                var result = _encounterRepository.Create(temp);
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

        public Result<EncounterDto> Get(long id)
        {
            return MapToDto(_encounterRepository.Get(id));
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

        public Result<EncounterDto> ApproveTouristMadeEncounter(long createdEncounterId)
        {
            try
            {
                Encounter encounter = _encounterRepository.Get(createdEncounterId);

                if (encounter == null)
                {
                    return Result.Fail(FailureCode.NotFound).WithError("Encounter not found");
                }

                encounter.Activate();
                _encounterRepository.SaveChanges();

                return MapToDto(encounter);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }

        public Result<EncounterDto> ArchiveTouristMadeEncounter(long archivedEncounterId)
        {
            try
            {
                Encounter encounter = _encounterRepository.Get(archivedEncounterId);

                if (encounter == null)
                {
                    return Result.Fail(FailureCode.NotFound).WithError("Encounter not found");
                }

                encounter.Archive();
                _encounterRepository.SaveChanges();

                return MapToDto(encounter);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }

        public Result<EncounterExecutionDto> Complete(long touristId, long encounterId)
        {
            try
            {
                EncounterExecutionDto encounterExecutionDto = _encounterExecutionService.SetCompletionTime(touristId, encounterId).Value;

                _userExperienceService.AddXP(_userExperienceService.GetByUserId(encounterExecutionDto.TouristId).Value.Id, _encounterRepository.Get(encounterId).ExperiencePoints);

                return encounterExecutionDto;
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }
    }
}
