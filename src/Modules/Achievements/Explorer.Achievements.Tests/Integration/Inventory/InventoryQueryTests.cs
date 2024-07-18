using Explorer.Achievements.API.Dtos;
using Explorer.Achievements.API.Public;
using Explorer.API.Controllers.Author;
using Explorer.BuildingBlocks.Core.UseCases;
using Microsoft.AspNetCore.Mvc;
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
    public class InventoryQueryTests:BaseAchievementsIntegrationTest
    {
        public InventoryQueryTests(AchievementsTestFactory factory) : base(factory) { }

        [Fact]
        public void Retrieves_all()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.GetAll(0, 0).Result)?.Value as PagedResult<InventoryDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(3);
            result.TotalCount.ShouldBe(3);
        }
        [Fact]
        public void Retrieves_one()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.Get(-2).Result)?.Value as InventoryDto;

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(-2);
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
