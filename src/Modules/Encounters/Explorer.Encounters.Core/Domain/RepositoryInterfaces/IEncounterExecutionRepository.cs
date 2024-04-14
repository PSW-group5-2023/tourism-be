using Explorer.BuildingBlocks.Core.UseCases;

namespace Explorer.Encounters.Core.Domain.RepositoryInterfaces
{
    public interface IEncounterExecutionRepository : ICrudRepository<EncounterExecution>
    {
        void SaveChanges();
        EncounterExecution GetByTouristIdAndEncounterId(long touristId, long encounterId);
        PagedResult<EncounterExecution> GetAllActiveByEncounterId(long encounterId);
    }
}
