using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class TourRatingRepository : ITourRatingRepository
    {
        private readonly ToursContext _dbContext;

        public TourRatingRepository(ToursContext dbContext)
        {
            _dbContext = dbContext;
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

    }
}
