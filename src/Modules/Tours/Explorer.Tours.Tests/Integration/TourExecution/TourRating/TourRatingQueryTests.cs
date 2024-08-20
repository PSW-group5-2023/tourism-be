using Explorer.API.Controllers.Tourist;
using Explorer.API.Controllers.Author.Authoring;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Rating;
using Explorer.Tours.API.Public.Rating;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Explorer.Tours.API.Dtos.Statistics;
using Explorer.Tours.API.Public.Tour;

namespace Explorer.Tours.Tests.Integration.TourExecution.TourRating
{
    [Collection("Sequential")]
    public class TourRatingQueryTests : BaseToursIntegrationTest
    {
        public TourRatingQueryTests(ToursTestFactory factory) : base(factory) { }

        [Fact]
        public void Retrieves_all()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateTouristController(scope);

            // Act
            var result = ((ObjectResult)controller.GetAll(0, 0).Result)?.Value as PagedResult<TourRatingDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(2);
            result.TotalCount.ShouldBe(2);
        }

        [Fact]
        public void Retrieves_one()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateTouristController(scope);

            //Act
            var result = ((ObjectResult)controller.Get(-1).Result)?.Value as TourRatingDto;

            //Assert
            result.ShouldNotBeNull();
            result.UserId.ShouldBe(-1);
            result.TourId.ShouldBe(-1);
            result.Mark.ShouldBe(4);
            result.Comment.ShouldBe("Bilo je veoma dobro");
        }

        [Fact]
        public void Retrieves_one_fails_invalid_id()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateTouristController(scope);

            //Act
            var result = (ObjectResult)controller.Get(-3).Result;

            //Assert
            result.StatusCode.ShouldBe(404);
        }

        [Fact]
        public void Retrieves_all_by_tour_id()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateTouristController(scope);

            //Act
            var result = ((ObjectResult)controller.GetByTourId(-1).Result)?.Value as List<TourRatingDto>;

            //Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(1);
        }

        [Fact]
        public void Retrieves_one_by_person_id_and_tour_id()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateTouristController(scope);

            //Act
            var result = ((ObjectResult)controller.GetByPersonIdAndTourId(-1, -1).Result)?.Value as TourRatingDto;

            //Assert
            result.ShouldNotBeNull();
            result.UserId.ShouldBe(-1);
            result.TourId.ShouldBe(-1);
            result.Mark.ShouldBe(4);
            result.Comment.ShouldBe("Bilo je veoma dobro");
        }

        [Fact]
        public void Retrieves_best_rated_statistics()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateAuthorController(scope);

            //Act
            var result = ((ObjectResult)controller.GetBestRatedStatistics().Result)?.Value as List<TourStatisticsDto>;

            //Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(2);
        }

        private static Explorer.API.Controllers.Tourist.TourRatingController CreateTouristController(IServiceScope scope)
        {
            return new Explorer.API.Controllers.Tourist.TourRatingController(scope.ServiceProvider.GetRequiredService<ITourRatingService>(), scope.ServiceProvider.GetRequiredService<ITourRatingMobileService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }

        private static Explorer.API.Controllers.Author.TourRatingController CreateAuthorController(IServiceScope scope)
        {
            return new Explorer.API.Controllers.Author.TourRatingController(scope.ServiceProvider.GetRequiredService<ITourRatingService>(), scope.ServiceProvider.GetRequiredService<ITourService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
