using Explorer.API.Controllers.Administrator.Administration;
using Explorer.API.Controllers.Author;
using Explorer.Tours.API.Dtos.Tour;
using Explorer.Tours.API.Public.Tour;
using Explorer.Tours.Core.Domain.Tours;
using Explorer.Tours.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;


namespace Explorer.Tours.Tests.Integration.Administration
{
    [Collection("Sequential")]
    public class TourKeyPointCommandTests : BaseToursIntegrationTest
    {
        public TourKeyPointCommandTests(ToursTestFactory factory) : base(factory)
        {
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
                TourId = 17
            };

            // Act
            var result = (ObjectResult)controller.Update(updatedEntity).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(404);
        }
 

        private static Explorer.API.Controllers.Administrator.Administration.TourKeyPointController CreateController(IServiceScope scope)
        {
            return new Explorer.API.Controllers.Administrator.Administration.TourKeyPointController(scope.ServiceProvider.GetRequiredService<ICheckpointService>(), scope.ServiceProvider.GetRequiredService<IPublicCheckpointService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }


    }
}
