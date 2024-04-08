using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using FluentResults;

namespace Explorer.Encounters.API.Public
{
    public interface IEncounterService
    {
        Result<PagedResult<EncounterDto>> GetPaged(int page, int pageSize);
        Result<EncounterDto> Create(EncounterDto encounterDto);
        Result<EncounterDto> Update(EncounterDto encounterDto);
        Result Delete(int id);
        Result<EncounterDto> Get(int id);
        Result<PagedResult<EncounterDto>> GetPagedByKeyPointIdsForTourist(List<long> keyPointIds, int page, int pageSize, long touristId);
        Result<EncounterDto> CreateForTourist(EncounterDto encounterDto, long touristId);
        Result<EncounterDto> UpdateForTourist(EncounterDto encounterDto, long touristId);
        Result<EncounterDto> DeleteForTourist(long id, long touristId);
        Result<PagedResult<EncounterDto>> GetPublicPagedForTourist(long touristId, int page, int pageSize);

        Result<PagedResult<EncounterDto>> GetPublicPagedForTourist(long touristId, int page, int pageSize);
    }
}
