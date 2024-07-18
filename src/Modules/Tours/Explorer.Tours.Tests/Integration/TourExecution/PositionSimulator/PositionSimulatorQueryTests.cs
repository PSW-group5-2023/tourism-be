using Explorer.API.Controllers.Execution;
using Explorer.Tours.API.Dtos.Execution;
using Explorer.Tours.API.Public.Execution;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Explorer.Tours.Tests.Integration.TourExecution.PositionSimulator
{
    [Collection("Sequential")]
    public class PositionSimulatorQueryTests : BaseToursIntegrationTest
    {
        public PositionSimulatorQueryTests(ToursTestFactory factory) : base(factory)
        {
        }

        [Fact]
        public void Retrieves_one()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            //Act
            var result = ((ObjectResult)controller.Get(-21).Result)?.Value as PositionSimulatorDto;

            //Assert
            result.ShouldNotBeNull();
            result.Latitude.ShouldBe(11.1);
            result.Longitude.ShouldBe(11.1);
            result.TouristId.ShouldBe(-21);
        }

        [Fact]
        public void Retrieves_one_fails_invalid_id()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            //Act
            var result = (ObjectResult)controller.Get(-1000).Result;

            //Assert
            result.StatusCode.ShouldBe(404);
        }

        [Fact]
        public void Retrieves_one_by_tourist_id()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            //Act
            var result = ((ObjectResult)controller.GetByTouristId(-21).Result)?.Value as PositionSimulatorDto;

            //Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(-21);
            result.Latitude.ShouldBe(11.1);
            result.Longitude.ShouldBe(11.1);
        }

        [Fact]
        public void Retrieves_one_by_tourist_id_fails_invalid_tourist_id()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            //Act
            var result = (ObjectResult)controller.GetByTouristId(-1000).Result;

            //Assert
            result.StatusCode.ShouldBe(404);
        }

        private static PositionSimulatorController CreateController(IServiceScope scope)
        {
            return new PositionSimulatorController(scope.ServiceProvider.GetRequiredService<IPositionSimulatorService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
