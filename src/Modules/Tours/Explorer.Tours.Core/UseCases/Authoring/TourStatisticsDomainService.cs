﻿using Explorer.Tours.API.Dtos.Statistics;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.ServiceInterfaces;
using Explorer.Tours.Core.Domain.Sessions;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases.Authoring
{
    public class TourStatisticsDomainService : ITourStatisticsDomainService
    {

        public TourStatisticsDomainService()
        {
        }

        public List<TourStatistics> CalculateAbandonedStatistics(List<Session> sessions)
        {
            var abandonedStatistics = new List<TourStatistics>();

            foreach (var session in sessions)
            {
                var matchingStat = abandonedStatistics.FirstOrDefault(stat => stat.TourId == session.TourId);

                if (session.SessionStatus == SessionStatus.ABANDONED)
                {
                    if (matchingStat != null)
                    {
                        matchingStat.NumberOfStats += 1;
                    }
                    else
                    {
                        TourStatistics stat = new TourStatistics(session.TourId, 1);
                        abandonedStatistics.Add(stat);
                    }
                }
            }

            return abandonedStatistics;
        }

        public List<TourStatistics> CalculateAttendanceStatistics(List<Session> sessions)
        {
            var attendanceStatistics = new List<TourStatistics>();

            foreach (var session in sessions)
            {
                var matchingStat = attendanceStatistics.FirstOrDefault(stat => stat.TourId == session.TourId);


                if (session.SessionStatus == SessionStatus.ACTIVE || session.SessionStatus == SessionStatus.COMPLETED)
                {
                    if (matchingStat != null)
                    {
                        matchingStat.NumberOfStats += 1;
                    }
                    else
                    {
                        TourStatistics stat = new TourStatistics(session.TourId, 1);
                        //stat.TourId = session.TourId;
                        //stat.NumberOfStats = 1;
                        attendanceStatistics.Add(stat);
                    }
                }
            }

            return attendanceStatistics;
        }

        public List<TourStatistics> CalculateBestRatedStatisticts(List<TourRating> ratings)
        {
            var bestRatedToursStats = new List<TourStatistics>();
            var tourIdToRatingSum = new Dictionary<long, double>();
            var tourIdToRatingCount = new Dictionary<long, int>();

            foreach (var rating in ratings)
            {
                if (tourIdToRatingSum.ContainsKey(rating.TourId))
                {
                    tourIdToRatingSum[rating.TourId] += rating.Mark;
                    tourIdToRatingCount[rating.TourId]++;
                }
                else
                {
                    tourIdToRatingSum[rating.TourId] = rating.Mark;
                    tourIdToRatingCount[rating.TourId] = 1;
                }
            }

            foreach (var tourId in tourIdToRatingSum.Keys)
            {
                var avgRating = tourIdToRatingSum[tourId] / tourIdToRatingCount[tourId];
                TourStatistics stat = new TourStatistics(tourId, avgRating);

                bestRatedToursStats.Add(stat);
            }

            return bestRatedToursStats;
        }

        public int CalculateNumberOfCompletedTours(List<Session> sessions, List<long> authorsTourIds)
        {
            int numberOfCompletedTours = 0;
            var uniqueSessions = new List<Session>();
            foreach (var session in sessions)
            {
                if (authorsTourIds.Contains(session.TourId))
                {
                    if (uniqueSessions.FirstOrDefault(s => s.TouristId == session.TouristId && s.TourId == session.TourId) == null && session.SessionStatus == SessionStatus.COMPLETED)
                    {
                        numberOfCompletedTours += 1;
                        uniqueSessions.Add(session);
                    }
                }
            }

            return numberOfCompletedTours;
        }

        public int CalculateNumberOfStartedTours(List<Session> sessions, List<long> authorsTourIds)
        {
            int numberOfStartedTours = 0;
            var uniqueSessions = new List<Session>();
            foreach (var session in sessions)
            {
                if(authorsTourIds.Contains(session.TourId))
                {
                    if(uniqueSessions.FirstOrDefault(s => s.TouristId == session.TouristId && s.TourId == session.TourId) == null)
                    {
                        numberOfStartedTours += 1;
                        uniqueSessions.Add(session);
                    }
                }
            }

            return numberOfStartedTours;
        }
    }
}
