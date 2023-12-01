using Explorer.API.Controllers.Administrator;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Infrastructure.Database;
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
    public class LocationChallangeCommandTests : BaseEncountersIntegrationTest
    {
        public LocationChallangeCommandTests(EncountersTestFactory factory) : base(factory)
        {
        }

        [Fact]
        public void Creates()
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
            result.LongitudeImage.ShouldBe(newEntity.LongitudeImage);

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
