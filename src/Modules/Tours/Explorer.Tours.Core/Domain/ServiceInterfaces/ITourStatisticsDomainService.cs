using Explorer.Tours.Core.Domain.Sessions;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.ServiceInterfaces
{
    public interface ITourStatisticsDomainService
    {
        List<TourStatistics> CalculateAttendanceStatistics(List<Session> sessions);
        List<TourStatistics> CalculateAbandonedStatistics(List<Session> sessions);
        List<TourStatistics> CalculateBestRatedStatisticts(List<TourRating> ratings);
        int CalculateNumberOfStartedTours(List<Session> sessions, List<long> authorsTourIds);
        int CalculateNumberOfCompletedTours(List<Session> sessions, List<long> authorsTourIds);
    }
}
