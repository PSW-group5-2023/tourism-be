using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using FluentResults;

namespace Explorer.Encounters.API.Public
{
    public interface IEncounterExecutionService
    {
        Result<EncounterExecutionDto> Create(EncounterExecutionDto encounterExecutionDto);
        Result<EncounterExecutionDto> Update(EncounterExecutionDto encounterExecutionDto);
        Result<EncounterExecutionDto> SetCompletionTime(long touristId, long encounterId);
        Result<EncounterExecutionDto> GetByTouristIdAndEnctounterId(long touristId, long encounterId);
        Result<PagedResult<EncounterExecutionDto>> GetAllActiveByEncounterId(long encounterId);
        Result Delete(int id);
        Result<EncounterExecutionDto> SetInRange(long encounterId, long touristId, bool inRange);
        Result<EncounterExecutionDto> CalculateCorrectAnswersPercentage(long touristId, List<SubmittedAnswerDto> answers, EncounterDto encounterDto);

    }
}
