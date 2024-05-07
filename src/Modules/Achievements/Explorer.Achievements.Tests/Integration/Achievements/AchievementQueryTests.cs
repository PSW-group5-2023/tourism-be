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

namespace Explorer.Achievements.Tests.Integration.Achievements
{
    [Collection("Sequential")]
    public class AchievementQueryTests : BaseAchievementsIntegrationTest
    {
        public AchievementQueryTests(AchievementsTestFactory factory) : base(factory) { }

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
            result.Results.Count.ShouldBe(3);
            result.TotalCount.ShouldBe(3);
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
