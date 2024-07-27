using Explorer.Achievements.API.Dtos;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using FluentResults;

namespace Explorer.Encounters.API.Public
{
    public interface IEncounterService
    {
        Result<PagedResult<EncounterDto>> GetPaged(int page, int pageSize);
        Result Delete(int id);
        Result<EncounterDto> Get(long id);
        Result<PagedResult<EncounterDto>> GetPagedByCheckpointIdsForTourist(List<long> checkpointIds, int page, int pageSize, long touristId);
        Result<PagedResult<EncounterDto>> GetPagedByCheckpointIds(List<long> checkpointIds, int page, int pageSize);
        Result<EncounterDto> CreateForTourist(EncounterDto encounterDto, long touristId);
        Result<EncounterDto> UpdateForTourist(EncounterDto encounterDto, long touristId);
        Result<EncounterDto> DeleteIfCreator(long id, long creatorId);
        Result<PagedResult<EncounterDto>> GetPublicPagedForTourist(long touristId, int page, int pageSize);
        Result<EncounterDto> ApproveTouristMadeEncounter(long createdEncounterId);
        Result<EncounterDto> ArchiveTouristMadeEncounter(long archivedEncounterId);
        Result<EncounterExecutionDto> Complete(long touristId, long encounterId);
        Result<EncounterExecutionDto> CompleteQuiz(long touristId, long encounterId, ICollection<SubmittedAnswerDto> answers);
        Result<EncounterDto> CreateForAuthor(EncounterDto encounterDto, long authorId);
        Result<EncounterDto> UpdateForAuthor(EncounterDto encounterDto, long authorId);
        Result<EncounterDto> CreateForAdministrator(EncounterDto encounterDto, long administratorId);
        Result<EncounterDto> UpdateForAdministrator(EncounterDto encounterDto, long administratorId);
        Result<SocialEncounterStatus> UpdateLocation(double latitude, double longitude, long encounterId, long touristId);
        Result AbandonEncounter(long encounterId, long touristId);
        Result<EncounterExecutionDto> StartEncounter(long encounterId, long touristId);
        Result<EncounterDto> GetEncounterByCheckpointId(int checkPointId);
       

    }
}
