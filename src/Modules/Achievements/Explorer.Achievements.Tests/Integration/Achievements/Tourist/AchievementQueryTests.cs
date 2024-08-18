using Explorer.Achievements.API.Dtos;
using Explorer.Achievements.API.Dtos.Tourist;
using Explorer.Achievements.API.Public;
using Explorer.API.Controllers.Tourist;
using Explorer.BuildingBlocks.Core.UseCases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Achievements.Tests.Integration.Achievements.Tourist
{
    [Collection("Sequential")]
    public class AchievementQueryTests : BaseAchievementsIntegrationTest
    {
        public AchievementQueryTests(AchievementsTestFactory factory) : base(factory)
        {
        }

        [Fact]
        public void Retrieves_all()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.GetAll(0, 0).Result)?.Value as PagedResult<AchievementDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(6);
            result.TotalCount.ShouldBe(6);
        }

        [Fact]
        public void Retrieves_one()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.Get(-2).Result)?.Value as AchievementModuleAchievementMobileDto;

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(-2);
        }

        [Fact]
        public void Retrieves_all_base_achievements()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.GetAllBaseAchievements().Result)?.Value as List<AchievementDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(5);
        }

        [Fact]
        public void Retrieves_all_complex_achievements()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.GetAllComplexAchievements().Result)?.Value as List<AchievementDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(1);
        }

        [Fact]
        public void Retrieves_all_complex_achievements_with_full_recipes()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.GetAllComplexAchievementsWithFullRecipes().Result)?.Value as List<AchievementWithFullRecipeMobileDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(1);
        }

        [Fact]
        public void Retrieves_one_complex_achievement_with_full_recipe()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.GetComplexAchievementWithFullRecipe(-6).Result)?.Value as AchievementWithFullRecipeMobileDto;

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(-6);
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
