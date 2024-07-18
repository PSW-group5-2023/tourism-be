using Explorer.Tours.Core.Domain.Rating;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface ITourRatingRepository
    {
        List<TourRating> GetByTourId(int tourId);
        List<TourRating> GetAll();
        TourRating GetByPersonIdAndTourId(long personId, long tourId);
    }
}
