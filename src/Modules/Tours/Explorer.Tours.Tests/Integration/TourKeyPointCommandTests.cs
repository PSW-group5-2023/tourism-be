using Explorer.API.Controllers.Administrator.Administration;
using Explorer.API.Controllers.Author;
using Explorer.Tours.API.Dtos.Tour;
using Explorer.Tours.API.Public.Tour;
using Explorer.Tours.Core.Domain.Tours;
using Explorer.Tours.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;


namespace Explorer.Tours.Tests.Integration
{
    [Collection("Sequential")]
    public class TourKeyPointCommandTests : BaseToursIntegrationTest
    {
        public TourKeyPointCommandTests(ToursTestFactory factory) : base(factory)
        {
        }

        [Fact]
        public void Creates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();
            var newEntity = new CheckpointDto
            {
                Name = "New key point",
                Description = "Newest key point.",
                Image = new Uri("http://keypoint.com/"),
                Longitude = 51.33,
                Latitude = -32.6,
                TourId = -2,
                Secret = "asd",
                PositionInTour = 1
            };

            // Act
            var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as CheckpointDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.Name.ShouldBe(newEntity.Name);

            // Assert - Database
            var storedEntity = dbContext.Checkpoints.FirstOrDefault(i => i.Name == newEntity.Name);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(result.Id);
        }

        [Fact]
        public void CreatesPublic()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();
            var newEntity = new PublicCheckpointDto
            {
                Name = "New public key point",
                Description = "Newest key point.",
                Image = new Uri("http://keypoint.com/"),
                Longitude = 51.33,
                Latitude = -32.6,
                Secret = "asd",
                Status = "Pending",
            };

            // Act
            var result = ((ObjectResult)controller.CreatePublic(newEntity).Result)?.Value as PublicCheckpointDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.Name.ShouldBe(newEntity.Name);

            // Assert - Database
            var storedEntity = dbContext.PublicCheckpoints.FirstOrDefault(i => i.Name == newEntity.Name);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(result.Id);
        }

        [Fact]
        public void CreateFailsInvalidData()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var newEntity = new CheckpointDto()
            {
                Name = "Test"
            };

            // Act
            var result = (ObjectResult)controller.Create(newEntity).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(400);
        }
        [Fact]
        public void CreatePublicFailsInvalidData()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var newEntity = new PublicCheckpointDto()
            {
                Name = "Test"
            };

            // Act
            var result = (ObjectResult)controller.CreatePublic(newEntity).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(400);
        }

        [Fact]
        public void Update()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();
            var updatedEntity = new CheckpointDto
            {
                Id = -1, 
                Name = "Test",
                Description = "Updated value",
                Image = new Uri("http://tacka1.com/"),
                Longitude = -12.3,
                Latitude = -24.22,
                TourId = -2,
                Secret = "asd",
                PositionInTour = 1
            };

            //Act
            var result = ((ObjectResult)controller.Update(updatedEntity).Result)?.Value as CheckpointDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldBe(-1);
            result.Name.ShouldBe(updatedEntity.Name);
            result.Description.ShouldBe(updatedEntity.Description);
            result.Image.ShouldBe(updatedEntity.Image);
            result.Latitude.ShouldBe(updatedEntity.Latitude);
            result.Longitude.ShouldBe(updatedEntity.Longitude);

            // Assert - Database
            var storedEntity = dbContext.Checkpoints.FirstOrDefault(i => i.Name == "Test");
            storedEntity.ShouldNotBeNull();
            storedEntity.Description.ShouldBe(updatedEntity.Description);
            var oldEntity = dbContext.Checkpoints.FirstOrDefault(i => i.Name == "Tacka 1");
            oldEntity.ShouldBeNull();
        }

        [Fact]
        public void UpdatePublicStatus()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();

            //Act
            var result = ((ObjectResult)controller.ChangeStatus(-4, "Approved").Result)?.Value as PublicCheckpointDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldBe(-4);
            result.Status.ShouldBe("Approved");

            // Assert - Database
            var storedEntity = dbContext.PublicCheckpoints.FirstOrDefault(i => i.Id == -4);
            storedEntity.ShouldNotBeNull();
            storedEntity.Status.ShouldBe(PublicCheckpointStatus.Approved);
        }


        [Fact]
        public void UpdateFailsInvalidValue()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var updatedEntity = new CheckpointDto
            {
                Id = -2, 
                Name = ""
            };

            //Act
            var result = (ObjectResult)controller.Update(updatedEntity).Result;

            //Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(400);

        }

        [Fact]
        public void UpdateFailInvalidId()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var updatedEntity = new CheckpointDto
            {
                Id = -1000,
                Name = "Test",
                Description = "Updated value",
                Image = new Uri("http://tacka1.com/"),
                Longitude = -12.3,
                Latitude = -24.22,
                TourId = -2
            };

            // Act
            var result = (ObjectResult)controller.Update(updatedEntity).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(404);
        }
        [Fact]
        public void Deletes()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();

            // Act
            var result = (OkResult)controller.Delete(-3);

            // Assert - Response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(200);

            // Assert - Database
            var storedCourse = dbContext.Checkpoints.FirstOrDefault(i => i.Id == -3);
            storedCourse.ShouldBeNull();
        }
        public void DeleteFailsInvalidId()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.Delete(-1000);

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(404);
        }

        private static Explorer.API.Controllers.Author.CheckpointController CreateController(IServiceScope scope)
        {
            return new Explorer.API.Controllers.Author.CheckpointController(scope.ServiceProvider.GetRequiredService<ICheckpointService>(), scope.ServiceProvider.GetRequiredService<IPublicCheckpointService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }


    }
}
