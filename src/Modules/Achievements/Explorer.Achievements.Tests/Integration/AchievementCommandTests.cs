using Explorer.Achievements.API.Dtos;
using Explorer.Achievements.API.Public;
using Explorer.Achievements.Infrastructure.Database;
using Explorer.API.Controllers.Author;
using Explorer.Tours.API.Dtos.Equipment;
using Explorer.Tours.API.Public.Equipment;
using Explorer.Tours.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Achievements.Tests.Integration
{
    [Collection("Sequential")]
    public class AchievementCommandTests : BaseAchievementsIntegrationTest
    {
        public AchievementCommandTests(AchievementsTestFactory factory) : base(factory) { }
        
        [Fact]
        public void Creates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<AchievementsContext>();
            var newEntity = new AchievementDto
            {
                Id = 100,
                Name = "Test Name",
                Description = "Test Description",
                Icon = new Uri("https://example.com/icon1.png"),
                Rarity = 1,
            };

            // Act
            var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as AchievementDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.Name.ShouldBe(newEntity.Name);

            // Assert - Database
            var storedEntity = dbContext.Achievements.FirstOrDefault(i => i.Name == newEntity.Name);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(result.Id);
        }

        [Fact]
        public void Create_fails_invalid_data()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var updatedEntity = new AchievementDto
            {
                Id = 101,              
                Icon = new Uri("https://example.com/icon1.png"),
            };

            // Act
            var result = (ObjectResult)controller.Create(updatedEntity).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(400);
        }

        [Fact]
        public void Deletes()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<AchievementsContext>();

            // Act
            var result = (OkResult)controller.Delete(-1);

            // Assert - Response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(200);

            // Assert - Database
            var storedCourse = dbContext.Achievements.FirstOrDefault(i => i.Id == -1);
            storedCourse.ShouldBeNull();
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

        private static AchievementController CreateController(IServiceScope scope)
        {
            return new AchievementController(scope.ServiceProvider.GetRequiredService<IAchievementService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
