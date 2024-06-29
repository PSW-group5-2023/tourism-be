using Explorer.API.Controllers.Author;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Tour;
using Explorer.Tours.API.Public.Tour;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Explorer.Tours.Tests.Integration.TourAuthoring.Checkpoint
{
    [Collection("Sequential")]
    public class CheckpointQueryTests : BaseToursIntegrationTest
    {
        public CheckpointQueryTests(ToursTestFactory factory) : base(factory)
        {
        }

        [Fact]
        public void RetrievesAll()
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
        public void RetrievesAllPublic()
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
        public void RetrievesOne()
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
        public void RetrievesByTourId()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            //Act
            var result = (ObjectResult)controller.GetByTourId(-3).Result;

            //Assert
            result.ShouldNotBe(null);
            result.StatusCode.ShouldBe(200);
        }

        [Fact]
        public void RetrievesByStatus()
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
        public void RetrievesOneFailedInvalidId()
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
        public void Update()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Create a DTO with updated data
            var updatedData = new CheckpointDto
            {
                Id = -3,
                Name = "Updated Name",
                Description = "Updated Description",
                Image = new Uri("http://newUri.com"),
                Longitude = 22.5,
                Latitude = 7,
                TourId = -2,
                Secret = "asd",
                PositionInTour = 1,
                AchievementId = 1
            };

            // Act
            var result = (ObjectResult)controller.Update(updatedData).Result;

            // Assert
            result.ShouldNotBe(null);
            result.StatusCode.ShouldBe(200);
        }
        [Fact]
        public void ChangeStatus()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.ChangeStatus(-3, "Denied").Result;

            // Assert
            result.ShouldNotBe(null);
            result.StatusCode.ShouldBe(200);
        }
        [Fact]
        public void UpdateFailInvalidId()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Create a DTO with updated data
            var updatedData = new CheckpointDto
            {
                Id = -3000,
                Name = "Updated Name",
                Description = "Updated Description",
                Image = new Uri("http://newUri.com"),
                Longitude = 22.5,
                Latitude = 7,
                TourId = -2
            };

            // Act
            var result = (ObjectResult)controller.Update(updatedData).Result;

            // Assert
            result.StatusCode.ShouldBe(404);
        }
        [Fact]
        public void UpdateFailIvalidData()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Create a DTO with updated data
            var updatedData = new CheckpointDto
            {
                Id = -3,
                Name = "",
                Description = "Updated Description",
                Image = new Uri("http://newUri.com"),
                Longitude = 22.5,
                Latitude = 7,
                TourId = 17
            };

            // Act
            var result = (ObjectResult)controller.Update(updatedData).Result;

            // Assert
            result.StatusCode.ShouldBe(400);
        }
        private static CheckpointController CreateController(IServiceScope scope)
        {
            return new CheckpointController(scope.ServiceProvider.GetRequiredService<ICheckpointService>(), scope.ServiceProvider.GetRequiredService<IPublicCheckpointService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
