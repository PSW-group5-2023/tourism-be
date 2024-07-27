using Explorer.BuildingBlocks.Core.UseCases;

namespace Explorer.Encounters.Core.Domain.RepositoryInterfaces
{
    public interface IEncounterRepository : ICrudRepository<Encounter>
    {
        public PagedResult<Encounter> GetPagedByCheckpointIds(List<long> checkpointIds, int page, int pageSize);
        public PagedResult<Encounter> GetPublicPaged(int page, int pageSize);
        public PagedResult<Encounter> GetPaged(int page, int pageSize);
        void SaveChanges();
        public Encounter GetNoTracking(long id);
        public Encounter Get(long id);
        public Encounter GetByCheckpointId(int checkpointId);
    }
}
