using Explorer.Achievements.API.Dtos;
using Explorer.Achievements.API.Public;
using Explorer.Achievements.Infrastructure.Database;
using Explorer.API.Controllers.Author;
using Explorer.Stakeholders.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Achievements.Tests.Integration.Inventory
{
    [Collection("Sequential")]
    public class InventoryCommandTests : BaseAchievementsIntegrationTest
    {
        public InventoryCommandTests(AchievementsTestFactory factory) : base(factory) { }

        [Fact]
        public void Creates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<AchievementsContext>();
            var newEntity = new InventoryDto
            {
                Id = 100,
                UserId = 5,
                AchievementsId = new List<int>() { -5, -9 }
            };
            // Act
            var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as InventoryDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.UserId.ShouldBe(newEntity.UserId);

            // Assert - Database
            var storedEntity = dbContext.Inventory.FirstOrDefault(i => i.UserId == newEntity.UserId);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(result.Id);
        }

        [Fact]
        public void Deletes()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<AchievementsContext>();

            // Act
            var result = (OkResult)controller.Delete(100);

            // Assert - Response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(200);

            // Assert - Database
            var storedCourse = dbContext.Achievements.FirstOrDefault(i => i.Id == 100);
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
        [Fact]
        public void AddAchievement()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<AchievementsContext>();
            var updatedEntity = new InventoryDto
            {
                Id = -2,
                UserId = -6,
                AchievementsId = new List<int>() { -3,-9}
            };
            // Act
            var result = ((ObjectResult)controller.AddAchievementToInventory(-6,-33).Result)?.Value as InventoryDto;

            // Assert
            result.UserId.ShouldBe(updatedEntity.UserId);

            // Assert - Database
            var storedEntity = dbContext.Inventory.FirstOrDefault(i => i.UserId == updatedEntity.UserId);
            storedEntity.ShouldNotBeNull();
            storedEntity.AchievementsId.Count.ShouldBe(3);
        }

        [Fact]
        public void AddComplexAchievement()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<AchievementsContext>();
            var requiredItems = new List<int>() { -4, -5 };
            var updatedEntity = new InventoryDto
            {
                Id = -2,
                UserId = -6,
                AchievementsId = new List<int>() { -3, -9 }
            };
            // Act
            var result = ((ObjectResult)controller.AddComplexAchievementToInventory(-6, requiredItems).Result)?.Value as InventoryDto;

            // Assert
            result.UserId.ShouldBe(updatedEntity.UserId);

            // Assert - Database
            var storedEntity = dbContext.Inventory.FirstOrDefault(i => i.UserId == updatedEntity.UserId);
            storedEntity.ShouldNotBeNull();
            storedEntity.AchievementsId.Count.ShouldBe(3);
        }

        private static InventoryController CreateController(IServiceScope scope)
        {
            return new InventoryController(scope.ServiceProvider.GetRequiredService<IInventoryService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
