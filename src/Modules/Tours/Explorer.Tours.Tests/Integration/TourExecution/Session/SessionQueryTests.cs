using Explorer.API.Controllers.Execution;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Execution;
using Explorer.Tours.API.Public.Execution;
using Explorer.Tours.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Explorer.Tours.Tests.Integration.TourExecution.Session
{
    [Collection("Sequential")]
    public class SessionQueryTests : BaseToursIntegrationTest
    {
        public SessionQueryTests(ToursTestFactory factory) : base(factory)
        {

        }

        [Theory]
        [InlineData(-21)]
        public void Get_active_by_tourist_id(int id)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();

            // Act
            var result = ((ObjectResult)controller.GetActiveSessionByTouristId(id).Result)?.Value as SessionDto;

            // Assert
            result.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(1)]
        public void Get_by_tourist_id_fails_no_session(int id)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();

            // Act
            var result = ((ObjectResult)controller.GetActiveSessionByTouristId(id).Result)?.Value as SessionDto;

            // Assert
            result.ShouldBeNull();
        }


        [Theory]
        [InlineData(-1, -21)]
        public void Get_by_tour_and_tourist_id(int tourId, int touristId)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();

            // Act
            var result = ((ObjectResult)controller.GetByTourAndTouristId(tourId, touristId).Result)?.Value as SessionDto;

            // Assert
            result.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(1, 1)]
        public void Get_by_tour_and_tourist_id_fails_no_session(int tourId, int touristId)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();

            // Act
            var result = ((ObjectResult)controller.GetByTourAndTouristId(tourId, touristId).Result)?.Value as SessionDto;

            // Assert
            result.ShouldBeNull();
        }

        [Theory]
        [InlineData(-21)]
        public void Gets_all_by_tourist_id(long touristId)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();

            // Act
            var result = ((ObjectResult)controller.GetAllByTouristId(touristId).Result)?.Value as List<SessionDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(3);
        }

        [Theory]
        [InlineData(-21)]
        public void Gets_paged_by_tourist_id(long touristId)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();

            // Act
            var result = ((ObjectResult)controller.GetPagedByTouristId(touristId, 0, 0).Result)?.Value as PagedResult<SessionDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(3);
            result.TotalCount.ShouldBe(3);
        }

        private static SessionController CreateController(IServiceScope scope)
        {
            return new SessionController(scope.ServiceProvider.GetRequiredService<ISessionService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
