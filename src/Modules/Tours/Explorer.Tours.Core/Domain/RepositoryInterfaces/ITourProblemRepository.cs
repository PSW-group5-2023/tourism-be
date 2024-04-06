using Explorer.Tours.Core.Domain.Problem;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface ITourProblemRepository
    {
        List<TourProblem> GetByTouristId(long touristId);
        List<TourProblem> GetByTourId(long tourId);
        TourProblem GiveDeadline(DateTime deadline, long tourProblemId);
        TourProblem PunishAuthor(string authorUsername, long tourId, long tourProblemId);

    }
}
