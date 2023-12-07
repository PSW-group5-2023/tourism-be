using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class TourDatabaseRepository : ITourRepository
    {
        private readonly ToursContext DbContext;
        private readonly DbSet<Tour> _dbSet;

        public TourDatabaseRepository(ToursContext dbContext)
        {
            DbContext = dbContext;
            _dbSet = DbContext.Set<Tour>();
        }

        public Tour Create(Tour entity)
        {
            _dbSet.Add(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public void Delete(long id)
        {
            var entity = Get(id);
            _dbSet.Remove(entity);
            DbContext.SaveChanges();
        }

        public Tour Get(long id)
        {
            var tour = _dbSet
                .Where(t => t.Id == id)
                .Include(t => t.KeyPoints.OrderBy(kp => kp.PositionInTour))
                .FirstOrDefault();
            return tour ?? throw new KeyNotFoundException("Not found: " + id);
        }

        public PagedResult<Tour> GetPagedByAuthorId(int authorId, int page, int pageSize)
        {
            var task = _dbSet.Include(t => t.KeyPoints.OrderBy(kp => kp.PositionInTour)).Where(t => t.AuthorId == authorId).GetPagedById(page, pageSize);
            task.Wait();
            return task.Result;
        }

        public PagedResult<Tour> GetPaged(int page, int pageSize)
        {
            var task = _dbSet.Include(t => t.KeyPoints.OrderBy(kp => kp.PositionInTour)).GetPagedById(page, pageSize);
            task.Wait();
            return task.Result;
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public Tour Update(Tour entity)
        {
            try
            {
                DbContext.Update(entity);
                DbContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new KeyNotFoundException(e.Message);
            }
            return entity;
        }

    }
}
