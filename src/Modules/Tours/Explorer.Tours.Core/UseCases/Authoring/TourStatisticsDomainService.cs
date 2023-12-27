using Explorer.Tours.API.Dtos.Statistics;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.ServiceInterfaces;
using Explorer.Tours.Core.Domain.Sessions;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Explorer.Tours.Core.UseCases.Authoring
{
    public class TourStatisticsDomainService : ITourStatisticsDomainService
    {

        public TourStatisticsDomainService()
        {
        }

        public Result<TourStatistics> GetSessionsByStatusForTourStatistics(int tourId, int sessionStatus, List<Session> sessions)
        {
            int number = 0;
            TourStatistics stat = new TourStatistics(tourId,number);
            SessionStatus status;

            switch (sessionStatus)
            {
                case 0:
                    status = SessionStatus.ACTIVE;
                    break;
                case 1:
                    status = SessionStatus.COMPLETED;
                    break;
                case 2:
                    status = SessionStatus.ABANDONED;
                    break;
                default:
                    return null;
            }
            foreach (var session in sessions)
            {

                if (session.TourId == tourId && session.SessionStatus == status)
                {
                    number++;
                }
            }
            stat.NumberOfStats = number;
            return stat;
        }

        public Result<TourStatistics> GetNumberSessionsByTour(int tourId, List<Session> sessions)
        {
            int number = 0;
            TourStatistics stat = new TourStatistics(tourId, number);
            foreach (var session in sessions)
            {

                if (session.TourId == tourId)
                {
                    number++;
                }
            }
            stat.NumberOfStats = number;
            return stat;
        }

        public Result<TourStatistics> GetStatisticsForCompletedKeypointOnTour(int tourId, int keyPointId, List<Session> sessions)
        {
            int number = 0;
            int numberOfSession = 0;
            TourStatistics stat = new TourStatistics(tourId, number);
            foreach (var session in sessions)
            {
                if(session.TourId == tourId)
                {
                    numberOfSession++;
                }
                if (session.TourId == tourId && session.CompletedKeyPoints.Any(cp => cp.KeyPointId == keyPointId))
                {
                    number++;
                }
            }
            stat.NumberOfStats = (double)number/numberOfSession * 100;
            return stat;
        }



    }
}
