using Explorer.BuildingBlocks.Core.UseCases;

namespace Explorer.Encounters.Core.Domain.RepositoryInterfaces
{
    public interface IEncounterRepository : ICrudRepository<Encounter>
    {
        public PagedResult<Encounter> GetPagedByKeyPointIds(List<long> keyPointIds, int page, int pageSize);
        public PagedResult<Encounter> GetPublicPaged(int page, int pageSize);
        void SaveChanges();
        public Encounter GetNoTracking(long id);
    }
}
