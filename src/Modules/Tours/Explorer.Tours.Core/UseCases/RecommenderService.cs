﻿using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Internal;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.API.Public.Authoring;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using Explorer.Tours.Core.UseCases.Authoring;
using FluentResults;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Explorer.Tours.Core.UseCases
{

    public class RecommenderService : BaseService<TourDto, Tour>, IRecommenderService
    {
        private readonly ITourRepository _tourRepository;
        private readonly IPreferencesRepository _preferencesRepository;
        private readonly ITourRatingRepository _tourRatingRepository;
        private readonly IInternalBoughtItemService _internalBoughtItemService;

        public RecommenderService(IMapper mapper, ITourRepository tourRepository, IPreferencesRepository preferencesRepository, ITourRatingRepository tourRatingRepository, IInternalBoughtItemService internalBoughtItemService) : base(mapper) 
        {
            _tourRepository = tourRepository;
            _preferencesRepository = preferencesRepository;
            _tourRatingRepository = tourRatingRepository;
            _internalBoughtItemService = internalBoughtItemService;
        }
        public double CalculateScore(int totalRatings, int totalBoughts,int countOfRatings, int countOfBoughts, double averageRating)
        {
            double ratingsPercentage = (countOfRatings / (double)totalRatings);
            double boughtsPercentage = (countOfBoughts / (double)totalBoughts);
            double normalizedRating = (averageRating / 5);

            return 0.3*ratingsPercentage + 0.5*boughtsPercentage + 0.3*normalizedRating;
        }
        public Result<PagedResult<TourDto>> GetRecommendedTours(int page, int pageSize, int userId)
        {
            var preference = _preferencesRepository.GetByUserId(userId);
            var tours = _tourRepository.GetPaged(page, pageSize);
            var publishedTours = tours.Results.Where(tour => tour.Status == Domain.Tours.TourStatus.Published).ToList();

            var usedBoughtItems = _internalBoughtItemService.GetUsedByUserId(userId);
            var usedTours = new List<TourDto>();
            var recommendedTours = new PagedResult<TourDto>(new List<TourDto>(), 0);
            var tourIndexes = new Dictionary<long, double>();

            foreach (var item in usedBoughtItems.Value)
            {
                usedTours.Add(MapToDto(_tourRepository.Get(item.TourId)));
            }


            foreach (var tour in publishedTours)
            {
                // similarity based on preferences tags
                var tagsSimilarity = calculateJaccardIndex(tour.Tags, preference.Tags);


                // similarity based on used tours
                var usedToursIndexes = 0.0;
                foreach (var item in usedTours)
                {
                    usedToursIndexes += calculateJaccardIndex(tour.Tags, item.Tags);
                }

                var usedToursSimilarity = usedToursIndexes / usedTours.Count;


                // similarity based on difficulty preference
                var difficultyRelativeError = Math.Abs((double)(tour.Difficulty - preference.DifficultyLevel)) / preference.DifficultyLevel;

                // make one similarity index and bind it to tour
                var averageSimilarityIndexes = (tagsSimilarity + usedToursSimilarity + 1 / difficultyRelativeError) / 3;
                tourIndexes[tour.Id] = averageSimilarityIndexes;
            }

            var sortedToursByIndexes = tourIndexes.OrderByDescending(x => x.Value);

            foreach(KeyValuePair<long, double> tour in sortedToursByIndexes)
            {
                recommendedTours.Results.Add(MapToDto(tours.Results.Find(t => t.Id == tour.Key)));
            }

            return recommendedTours;
        }

        public double calculateJaccardIndex(List<string> firstList, List<string> secondList)
        {
            var intersection = firstList.Intersect(secondList).Count();
            var union = firstList.Union(secondList).Count();

            return intersection / union;
        }

        public Result<PagedResult<TourDto>> GetActive(int userId, int page, int pageSize)
        {
            DateTime lastWeek = DateTime.Today.AddDays(-7);
            var allTours = _tourRepository.GetPaged(page, pageSize).Results.Where(x=> x.Status == TourStatus.Published);
            int totalRatingsInLastWeek = _tourRatingRepository.GetAll().Where(x => x.DateOfCommenting >= lastWeek)?.Count() ?? 0;
            int totalBoughts = _internalBoughtItemService.GetAll().Value?.Count() ?? 0;
            var tourScores = new Dictionary<long, double>();

            foreach (var tour in allTours)
            {
                var tourRatingsInLastWeek = _tourRatingRepository.GetByTourId((int)tour.Id).Where(x => x.DateOfCommenting >= lastWeek).ToList();
                double averageRating = 0;
                int countOfRatings = tourRatingsInLastWeek?.Count() ?? 0;
                if (totalRatingsInLastWeek > 15)
                {
                    countOfRatings = 0;
                //Bayesian average za average i broj ratinga
                }
                if (countOfRatings > 15)
                {
                    averageRating = tourRatingsInLastWeek.Sum(r => r.Mark) / (double)countOfRatings;
                }
                int countOfBoughts = _internalBoughtItemService.GetByTourId(tour.Id).Value?.Count() ?? 0;
                tourScores[tour.Id] = CalculateScore(totalRatingsInLastWeek, totalBoughts, countOfRatings, countOfBoughts, averageRating);
            }
            //return MapToDto(sortedTours);
            return null;
        }
    }
}
