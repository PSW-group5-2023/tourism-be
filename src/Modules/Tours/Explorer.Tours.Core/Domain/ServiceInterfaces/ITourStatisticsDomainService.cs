using Explorer.Tours.Core.Domain.Sessions;
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
        Result<TourStatistics> GetSessionsByStatusForTourStatistics(int tourId, int sessionStatus, List<Session> sessions);
        Result<TourStatistics> GetNumberSessionsByTour(int tourId, List<Session> sessions);
        Result<TourStatistics> GetStatisticsForCompletedKeypointOnTour(int tourId, int keyPointId, List<Session> sessions);
    }
}
