using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class TourDatabaseRepository : CrudDatabaseRepository<Tour, ToursContext>, ITourRepository
    {
        public TourDatabaseRepository(ToursContext dbContext) : base(dbContext) { }

        public Tour GetWithKeyPoints(int id)
        {
            var tour = DbContext.Tour
                .Where(t => t.Id == id)
                .Include(t => t.KeyPoints)
                .FirstOrDefault();
            return tour ?? throw new KeyNotFoundException("Not found: " + id);
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }
    }
}
