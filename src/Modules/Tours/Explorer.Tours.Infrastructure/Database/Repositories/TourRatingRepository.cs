using Explorer.Tours.Core.Domain.Rating;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class TourRatingRepository : ITourRatingRepository
    {
        private readonly ToursContext _dbContext;
        private readonly DbSet<TourRating> _dbSet;

        public TourRatingRepository(ToursContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TourRating>();
        }

        public List<TourRating> GetByTourId(int tourId)
        {
            var tourRatings = _dbContext.TourRatings.Where(x => x.TourId == tourId).ToList();
            return tourRatings;
        }

        public List<TourRating> GetAll()
        {
            var query = _dbContext.TourRatings;
            return query.ToList();
        }

        public TourRating GetByUserIdAndTourId(long userId, long tourId)
        {
            return _dbSet.Where(tr => tr.UserId == userId && tr.TourId == tourId).FirstOrDefault()
                ?? throw new KeyNotFoundException($"Not found: personId = {userId}, tourId = {tourId}");
        }
    }
}
