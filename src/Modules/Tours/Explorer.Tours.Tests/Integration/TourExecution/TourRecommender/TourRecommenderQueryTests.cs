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

        [Fact]
        public void RetrievesRecommendedByTouristId()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.GetRecommendedToursForTourist(0, 0, -24).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(200);
        }


        [Fact]
        public void RetrievesActiveByTouristId()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.GetActiveToursForTourist(0, 0, -24).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(200);
        }


    }
}