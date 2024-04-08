using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using FluentResults;

namespace Explorer.Encounters.API.Public
{
    public interface IEncounterExecutionService
    {
        /*Result<PagedResult<EncounterExecutionDto>> GetPaged(int page, int pageSize);*/
        Result<EncounterExecutionDto> Create(EncounterExecutionDto encounterExecutionDto);
        Result<EncounterExecutionDto> Update(EncounterExecutionDto encounterExecutionDto);
        Result Delete(int id);
        Result<EncounterExecutionDto> Get(int id);

        Result<EncounterExecutionDto> Complete(long touristId, long challengeId);

        /*Result<PagedResult<EncounterExecutionDto>> GetPagedByKeyPointIds(List<int> keyPointIds, int page, int pageSize);*/

        Result<EncounterExecutionDto> GetByTouristIdAndEnctounterId(long touristId, long encounterId);
        /*Result<List<long>> GetUserIds(long challengeId);*/
    }
}
