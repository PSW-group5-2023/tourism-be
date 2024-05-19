using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Core.Domain;
using Explorer.Encounters.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.API.Dtos.Tour;
using Explorer.Tours.API.Internal;
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


        public Result<EncounterDto> CreateForAdministrator(EncounterDto encounterDto, long administratorId)
        {
            try
            {
                encounterDto.Status = 1; //Setting status on ACTIVE no matter what came from controller
                encounterDto.CreatorId = administratorId;

                if (encounterDto.KeyPointId != null) throw new ArgumentException("Administrator can only create public encounters.");

                var result = _encounterRepository.Create(MapToEncounter(encounterDto));
                return MapToDto(result);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }

        private bool IsAuthorOfKeyPoint(long authorId, long keypointId)
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
                encounterDto.CreatorId = touristId;
                if (encounterDto.KeyPointId != null) throw new ArgumentException("Tourist is not allowed to add encounter to a keypoint.");

                var result = _encounterRepository.Create(MapToEncounter(encounterDto));
                return MapToDto(result);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }

        public Result<EncounterDto> DeleteIfCreator(long id, long creatorId)
        {
            try
            {
                var encounter = _encounterRepository.Get(id);
                if (creatorId != encounter.CreatorId) throw new ArgumentException("User isn't the owner of the encounter");
                _encounterRepository.Delete(id);
                return Result.Ok();
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
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
            return MapToDto(filteredResults);
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
            return MapToDto(filteredResults);
        }

        public Result<EncounterDto> UpdateForTourist(EncounterDto encounterDto, long touristId)
        {
            try
            {
                var encounter = _encounterRepository.GetNoTracking(encounterDto.Id);
                if (touristId != encounter.CreatorId) throw new ArgumentException("User isn't the owner of the encounter");
                if (encounterDto.KeyPointId != null) throw new ArgumentException("Tourist is not allowed to add encounter to a keypoint.");
                encounterDto.CreatorId = encounter.CreatorId;
                encounterDto.Status = (int)EncounterStatus.Draft; // After update tourist made encounter needs to be approved again
                var result = _encounterRepository.Update(MapToEncounter(encounterDto));
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

        public Result<EncounterDto> CreateForAuthor(EncounterDto encounterDto, long authorId)
        {
            try
            {
                encounterDto.Status = 1; //Setting status on ACTIVE no matter what came from controller
                encounterDto.CreatorId = authorId;

                if (encounterDto.KeyPointId == null) throw new ArgumentException("Author can only create an encounter for a KeyPoint.");
                if (!IsAuthorOfKeyPoint(encounterDto.CreatorId, (long)encounterDto.KeyPointId)) throw new ArgumentException("This author is not the author of selected KeyPoint.");
                encounterDto = SetEncounterLocationByKeyPoint(encounterDto);

                var result = _encounterRepository.Create(MapToEncounter(encounterDto));
                return MapToDto(result);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }

        private EncounterDto SetEncounterLocationByKeyPoint(EncounterDto encounterDto)
        {
            TourKeyPointDto tourKeyPointDto = _internalKeyPointService.Get((long)encounterDto.KeyPointId).Value;
            encounterDto.Longitude = tourKeyPointDto.Longitude;
            encounterDto.Latitude = tourKeyPointDto.Latitude;
            return encounterDto;
        }

        private Encounter MapToEncounter(EncounterDto encounterDto)
        {
            if (encounterDto.Type == 0)
            {
                return _mapper.Map<SocialEncounter>(encounterDto);
            }
            else if (encounterDto.Type == 1)
            {
                return _mapper.Map<LocationEncounter>(encounterDto);
            }
            else
            {
                return _mapper.Map<Encounter>(encounterDto);
            }
        }

        public Result<EncounterDto> UpdateForAuthor(EncounterDto encounterDto, long authorId)
        {
            try
            {
                var encounter = _encounterRepository.GetNoTracking(encounterDto.Id);
                if (authorId != encounter.CreatorId) throw new ArgumentException("Author isn't the owner of the encounter");
                if (encounterDto.KeyPointId == null) throw new ArgumentException("Author cannot remove an encounter from a KeyPoint.");
                if (encounterDto.KeyPointId != encounter.KeyPointId) encounterDto = SetEncounterLocationByKeyPoint(encounterDto);
                var result = _encounterRepository.Update(MapToEncounter(encounterDto));
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

        public Result<EncounterDto> UpdateForAdministrator(EncounterDto encounterDto, long administratorId)
        {
            try
            {
                if (encounterDto.KeyPointId != null) throw new ArgumentException("Administrator is not allowed to add encounter to a keypoint.");
                var result = _encounterRepository.Update(MapToEncounter(encounterDto));
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

        public Result<PagedResult<EncounterDto>> GetPagedByKeyPointIds(List<long> keyPointIds, int page, int pageSize)
        {
            var result = _encounterRepository.GetPagedByKeyPointIds(keyPointIds, page, pageSize);
            return MapToDto(result);
        }

        // Updates the location for a tourist on a social encounter and checks how many tourists are in range. If enough, completes the encounter for every tourist
        public Result<SocialEncounterStatus> UpdateLocation(double latitude, double longitude, long encounterId, long touristId)
        {
            // Fetches the encounter and checks type before explicitly casting
            var encounter = _encounterRepository.Get(encounterId);
            if (encounter.Type != EncounterType.Social) return Result.Fail(FailureCode.InvalidArgument).WithError("Cannot track location for non-social encounters.");
            var socialEncounter = (SocialEncounter)encounter;

            // Updates the status of encounter execution
            _encounterExecutionService.SetInRange(encounterId, touristId, socialEncounter.IsInRange(latitude, longitude));

            // Completes for all if criteria is met
            var activeExecutions = _encounterExecutionService.GetAllActiveByEncounterId(encounterId).Value.Results;
            var touristsInRange = activeExecutions.Where(ee => ee.InRange).Count();
            if (touristsInRange >= socialEncounter.RequiredAttendance)
            {
                foreach (var execution in activeExecutions)
                {
                    Complete(execution.TouristId, execution.EncounterId);
                }
            }

            return Result.Ok(new SocialEncounterStatus()
            {
                NumberOfTourists = touristsInRange,
                Completed = touristsInRange >= socialEncounter.RequiredAttendance,
            });
        }

        public Result AbandonEncounter(long encounterId, long touristId)
        {
            var encounterExecution = _encounterExecutionService.GetByTouristIdAndEnctounterId(touristId, encounterId);
            if (encounterExecution.IsFailed) return Result.Fail(FailureCode.Internal).WithError("Encounter is not started");
            _encounterExecutionService.Delete((int)encounterExecution.Value.Id);
            return Result.Ok();
        }

        public Result<EncounterExecutionDto> StartEncounter(long encounterId, long touristId)
        {
            var encounterExecution = _encounterExecutionService.GetByTouristIdAndEnctounterId(touristId, encounterId);
            if (encounterExecution.IsSuccess) return Result.Fail(FailureCode.Internal).WithError("Encounter already started");
            return _encounterExecutionService.Create(new EncounterExecutionDto()
            {
                TouristId = touristId,
                EncounterId = encounterId,
                ActivationTime = DateTime.UtcNow,
                CompletionTime = null,
                InRange = false,
            });
        }
    }
}
