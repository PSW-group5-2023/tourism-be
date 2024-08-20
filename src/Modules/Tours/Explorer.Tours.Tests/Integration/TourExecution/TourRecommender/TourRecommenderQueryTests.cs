using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Tour;
using Explorer.Tours.API.Internal;
using Explorer.Tours.API.Public.Tour;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Explorer.Tours.Tests.Integration.TourExecution.TourRecommender
{

    [Collection("Sequential")]
    public class TourRecommenderQueryTests : BaseToursIntegrationTest
    {
        public TourRecommenderQueryTests(ToursTestFactory factory) : base(factory)
        {
        }
        private static Explorer.API.Controllers.Tourist.TourController CreateController(IServiceScope scope)
        {
            return new Explorer.API.Controllers.Tourist.TourController(scope.ServiceProvider.GetRequiredService<ITourService>(), scope.ServiceProvider.GetRequiredService<IRecommenderService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }

        //[Fact]
        //public void Get_recommended_by_touristId()
        //{
        //    // Arrange
        //    using var scope = Factory.Services.CreateScope();
        //    var controller = CreateController(scope);

        //    // Act
        //    var result = (ObjectResult)controller.GetRecommendedToursForTourist(0, 0, -24).Result;

        //    // Assert
        //    result.ShouldNotBeNull();
        //    result.StatusCode.ShouldBe(200);
        //}

        //[Fact]
        //public void Get_recommended_by_touristId_fails_invalid_touristId()
        //{
        //    // Arrange
        //    using var scope = Factory.Services.CreateScope();
        //    var controller = CreateController(scope);

        //    // Act
        //    var result = (ObjectResult)controller.GetRecommendedToursForTourist(0, 0, -1000).Result;

        //    // Assert
        //    result.StatusCode.ShouldBe(400);
        //}

        [Fact]
        public void Get_recommended_tours_from_followings()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.GetRecommendedToursFromFollowings(-1, -24).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(200);
        }

        [Fact]
        public void Get_recommended_tours_from_followings_fails_invalid_touristId()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.GetRecommendedToursFromFollowings(-1, -1000).Result;

            // Assert
            result.StatusCode.ShouldBe(400);
        }

        //[Fact]
        //public void Get_active_by_touristId()
        //{
        //    // Arrange
        //    using var scope = Factory.Services.CreateScope();
        //    var controller = CreateController(scope);

        //    // Act
        //    var result = (ObjectResult)controller.GetActiveToursForTourist(0, 0, -24).Result;

        //    // Assert
        //    result.ShouldNotBeNull();
        //    result.StatusCode.ShouldBe(200);
        //}

        //[Fact]
        //public void Get_active_by_touristId_fails_invalid_id()
        //{
        //    // Arrange
        //    using var scope = Factory.Services.CreateScope();
        //    var controller = CreateController(scope);

        //    // Act
        //    var result = (ObjectResult)controller.GetActiveToursForTourist(0, 0, -1000).Result;

        //    // Assert
        //    result.ShouldNotBeNull();
        //    result.StatusCode.ShouldBe(400);
        //}

        [Fact]
        public void Filter_recommended_tours()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.FilterRecommendedTours(-1, -12, 2).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(200);
        }

        [Fact]
        public void Filter_recommended_tours_fails_invalid_userId()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.FilterRecommendedTours(-1,-1000, 2).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(400);
        }
    }
}