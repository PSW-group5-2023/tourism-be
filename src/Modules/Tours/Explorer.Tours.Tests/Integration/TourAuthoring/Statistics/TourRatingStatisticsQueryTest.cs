﻿using Explorer.API.Controllers.Author;
using Explorer.API.Controllers.Author.Authoring;
using Explorer.Tours.API.Dtos.Statistics;
using Explorer.Tours.API.Public.Rating;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Explorer.Tours.Tests.Integration.TourAuthoring.Statistics
{
    [Collection("Sequential")]
    public class TourRatingStatisticsQueryTest : BaseToursIntegrationTest
    {
        public TourRatingStatisticsQueryTest(ToursTestFactory factory) : base(factory)
        {

        }

        [Fact]
        public void Get_best_rated_tours_stats()
        {
            // Arange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.GetBestRatedStatistics().Result)?.Value as List<TourStatisticsDto>;

            // Assert
            result.ShouldNotBeNull();
        }

        private static TourRatingController CreateController(IServiceScope scope)
        {
            return new TourRatingController(scope.ServiceProvider.GetRequiredService<ITourRatingService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
