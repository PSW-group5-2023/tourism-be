using Explorer.Tours.Core.Domain.Rating;
using Explorer.Tours.Core.Domain.Sessions;
using Explorer.Tours.Core.Domain.Statistics;
using FluentResults;

namespace Explorer.Tours.Core.Domain.ServiceInterfaces
{
    public interface ITourStatisticsDomainService
    {
        List<TourStatistics> CalculateAttendanceStatistics(List<Session> sessions);
        List<TourStatistics> CalculateAbandonedStatistics(List<Session> sessions);
        List<TourStatistics> CalculateBestRatedStatisticts(List<TourRating> ratings);
        int CalculateNumberOfStartedTours(List<Session> sessions, List<long> authorsTourIds);
        int CalculateNumberOfCompletedTours(List<Session> sessions, List<long> authorsTourIds);
        Result<TourStatistics> GetSessionsByStatusForTourStatistics(int tourId, int sessionStatus, List<Session> sessions);
        Result<TourStatistics> GetNumberSessionsByTour(int tourId, List<Session> sessions);
        Result<TourStatistics> GetStatisticsForCompletedKeypointOnTour(int tourId, int keyPointId, List<Session> sessions);
        List<int> CalculateTourCompletionPercentage(List<Session> sessions, List<long> authorsTourIds);
    }
}
