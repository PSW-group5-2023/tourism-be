using Explorer.Achievements.API.Dtos;
using Explorer.Achievements.API.Public;
using Explorer.Achievements.Infrastructure.Database;
using Explorer.API.Controllers.Tourist;
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
        public void AddAchievement()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope, "-6");
            var dbContext = scope.ServiceProvider.GetRequiredService<AchievementsContext>();
            var updatedEntity = new InventoryDto
            {
                Id = -2,
                UserId = -6,
                Achievements = new Dictionary<int, int>{
            { -4, 1 }
        }
            };
            // Act
            var result = ((ObjectResult)controller.AddAchievementToInventory(-5).Result)?.Value as InventoryDto;

            // Assert
            result.UserId.ShouldBe(updatedEntity.UserId);

            // Assert - Database
            var storedEntity = dbContext.Inventory.FirstOrDefault(i => i.UserId == updatedEntity.UserId);
            storedEntity.ShouldNotBeNull();
            storedEntity.Achievements.Count.ShouldBe(3);
        }

/*
        [Fact]
        public void AddComplexAchievement()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope, "-6");
            var dbContext = scope.ServiceProvider.GetRequiredService<AchievementsContext>();
            var requiredItems = new List<int>() { -4, -5 };
            var updatedEntity = new InventoryDto
            {
                Id = -2,
                UserId = -6,
                AchievementsId = new List<int>() { -3, -9 }
            };
            // Act
            var result = ((ObjectResult)controller.AddComplexAchievementToInventory(requiredItems).Result)?.Value as InventoryDto;

            // Assert
            result.UserId.ShouldBe(updatedEntity.UserId);

            // Assert - Database
            var storedEntity = dbContext.Inventory.FirstOrDefault(i => i.UserId == updatedEntity.UserId);
            storedEntity.ShouldNotBeNull();
            storedEntity.AchievementsId.Count.ShouldBe(3);
        } 
*/

        private static InventoryController CreateController(IServiceScope scope, string userId)
        {
            return new InventoryController(scope.ServiceProvider.GetRequiredService<IInventoryService>())
            {
                ControllerContext = BuildAchievementContext(userId)
            };
        }
    }
}
