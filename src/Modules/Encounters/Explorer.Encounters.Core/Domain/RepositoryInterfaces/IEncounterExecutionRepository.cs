using Explorer.BuildingBlocks.Core.UseCases;

namespace Explorer.Encounters.Core.Domain.RepositoryInterfaces
{
    public interface IEncounterExecutionRepository : ICrudRepository<EncounterExecution>
    {
        EncounterExecution GetByTouristIdAndEncounterId(long touristId, long encounterId);
    }
}
