using Explorer.API.Controllers.Administrator;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Infrastructure.Database;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.Tests.Integration
{
    [Collection("Sequential")]
    public class ChallengeCommandTests : BaseEncountersIntegrationTest
    {
        public ChallengeCommandTests(EncountersTestFactory factory) : base(factory)
        {
        }

        [Fact]
        public void Creates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();
            var newEntity = new ChallengeDto
            {
                AdministratorId = -1,
                Description = "Na očaravajućem ostrvu Santorini, turista može se suočiti s izazovom istraživanja skrivenih staza i slikovitih sokaka, otkrivajući autentične grčke trenutke izvan uobičajenih turističkih ruta.",
                Name = "asdasdsadas",
                Status = 0,
                Type = 0,
                Longitude = 50,
                Latitude = 50
            };

            // Act
            var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as ChallengeDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.Name.ShouldBe(newEntity.Name);
            result.Description.ShouldBe(newEntity.Description);
            result.Longitude.ShouldBe(newEntity.Longitude);
            result.Latitude.ShouldBe(newEntity.Latitude);

            // Assert - Database
            var storedEntity = dbContext.Challenges.FirstOrDefault(i => i.Id == result.Id);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(result.Id);
        }

        [Fact]
        public void Creates_location_challange()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();
            var newEntity = new LocationChallengeDto
            {
                AdministratorId = -1,
                Description = "Pronadji datu sliku, tacnije mjesto sa koje je slika uslikana i zadrzi se 30 sekundi tacno na toj lokaciji.",
                Name = "Izazov 1",
                Status = 0,
                Type = 1,
                Longitude = 50,
                Latitude = 50,
                Image = "https://upload.wikimedia.org/wikipedia/commons/1/1f/Katedrala_Novi_Sad_-_Srbija.JPG",
                LatitudeImage = 49.8213,
                LongitudeImage = 19.2318,
                Range = 15
            };


            // Act
            var result = ((ObjectResult)controller.CreateLocationChallange(newEntity).Result)?.Value as LocationChallengeDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.Name.ShouldBe(newEntity.Name);
            result.Description.ShouldBe(newEntity.Description);
            result.Type.ShouldBe(newEntity.Type);
            result.Longitude.ShouldBe(newEntity.Longitude);
            result.Latitude.ShouldBe(newEntity.Latitude);
            result.Image.ShouldBe(newEntity.Image);
            result.LatitudeImage.ShouldBe(newEntity.LatitudeImage);
            result.LongitudeImage.ShouldBe(newEntity.LongitudeImage);
            result.Range.ShouldBe(newEntity.Range);

            // Assert - Database
            var storedEntity = dbContext.Challenges.FirstOrDefault(i => i.Id == result.Id);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(result.Id);

        }

        [Fact]
        public void Create_fails_invalid_data()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var updatedEntity = new ChallengeDto
            {
                Status = 20
            };

            // Act
            var result = (ObjectResult)controller.Create(updatedEntity).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(400);
        }

        [Fact]
        public void Create_location_challenge_fails_invalid_data()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var newEntity = new LocationChallengeDto
            {
                Status = 20
            };

            // Act
            var result = (ObjectResult)controller.CreateLocationChallange(newEntity).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(400);
        }

        [Fact]
        public void Updates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();
            var updatedEntity = new ChallengeDto
            {
                Id = -1,
                AdministratorId = -1,
                Name = "Update",
                Description = "update test"
            };

            // Act
            var result = ((ObjectResult)controller.Update(updatedEntity).Result)?.Value as ChallengeDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldBe(-1);
            result.Name.ShouldBe(updatedEntity.Name);
            result.Description.ShouldBe(updatedEntity.Description);

            // Assert - Database
            var storedEntity = dbContext.Challenges.FirstOrDefault(i => i.Name == "Update");
            storedEntity.ShouldNotBeNull();
            storedEntity.Description.ShouldBe(updatedEntity.Description);
            var oldEntity = dbContext.Challenges.FirstOrDefault(i => i.Name == "Skrivene staze");
            oldEntity.ShouldBeNull();
        }

        [Fact]
        public void Updates_location_challenge()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();
            var updatedEntity = new LocationChallengeDto
            {
                Id = -2,
                AdministratorId = -4,
                Name = "Update name",
                Description = "update test",
                Image = "https://upload.wikimedia.org/wikipedia/commons/1/1f/Katedrala_Novi_Sad_-_Srbija.JPG"
            };

            // Act
            var result = ((ObjectResult)controller.UpdateLocationChallenge(updatedEntity).Result)?.Value as LocationChallengeDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldBe(-2);
            result.Name.ShouldBe(updatedEntity.Name);
            result.Description.ShouldBe(updatedEntity.Description);
        }

        [Fact]
        public void Update_fails_invalid_id()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var updatedEntity = new ChallengeDto
            {
                Id = -1000,
                AdministratorId = -1,
                Name = "Test",
                Description = "failed update test"
            };

            // Act
            var result = (ObjectResult)controller.Update(updatedEntity).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(404);
        }

        [Fact]
        public void Delete_fails_invalid_id()
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

        [Fact]
        public void Deletes_location_challenge()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();

            // Act
            var result = (OkResult)controller.DeleteLocationChallenge(-5);

            // Assert - Response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(200);

        }


        private static ChallengeController CreateController(IServiceScope scope)
        {
            return new ChallengeController(scope.ServiceProvider.GetRequiredService<IChallengeService>(), scope.ServiceProvider.GetRequiredService<ILocationChallengeService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
