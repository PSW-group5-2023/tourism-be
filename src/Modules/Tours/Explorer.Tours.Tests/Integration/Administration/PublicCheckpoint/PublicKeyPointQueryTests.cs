using Explorer.API.Controllers.Administrator.Administration;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Tour;
using Explorer.Tours.API.Public.Tour;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Explorer.Tours.Tests.Integration.Administration.PublicCheckpoint
{
    [Collection("Sequential")]
    public class PublicCheckpointQueryTests : BaseToursIntegrationTest
    {
        public PublicCheckpointQueryTests(ToursTestFactory factory) : base(factory)
        {
        }

        [Fact]
        public void Retrieves_all()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            //Act
            var result = ((ObjectResult)controller.GetAll(0, 0).Result)?.Value as PagedResult<CheckpointDto>;

            //Assert
            result.ShouldNotBe(null);
            result.Results.Count.ShouldBe(19);
            result.TotalCount.ShouldBe(19);
        }

        [Fact]
        public void Retrieves_all_public()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            //Act
            var result = ((ObjectResult)controller.GetAllPublic(0, 0).Result)?.Value as PagedResult<PublicCheckpointDto>;

            //Assert
            result.ShouldNotBe(null);
            result.Results.Count.ShouldBe(4);
            result.TotalCount.ShouldBe(4);
        }

        [Fact]
        public void Retrieves_one()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            //Act
            var result = (ObjectResult)controller.Get(-1).Result;

            //Assert
            result.ShouldNotBe(null);
            result.StatusCode.ShouldBe(200);
        }

        [Fact]
        public void Retrieves_by_status()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            //Act
            var result = (ObjectResult)controller.GetByStatus("Pending").Result;

            //Assert
            result.ShouldNotBe(null);
            result.StatusCode.ShouldBe(200);
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
        public void Changes_status()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.ChangeStatus(-4, "Approved").Result;

            // Assert
            result.ShouldNotBe(null);
            result.StatusCode.ShouldBe(200);
        }

        private static TourKeyPointController CreateController(IServiceScope scope)
        {
            return new TourKeyPointController(scope.ServiceProvider.GetRequiredService<ICheckpointService>(), scope.ServiceProvider.GetRequiredService<IPublicCheckpointService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}

