using Explorer.API.Controllers;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Stakeholders.Core.UseCases;
using Explorer.Tours.API.Dtos.Tour;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Explorer.Encounters.Tests.Integration
{
    [Collection("Sequential")]
    public class EncounterQueryTests : BaseEncountersIntegrationTest
    {
        public EncounterQueryTests(EncountersTestFactory factory) : base(factory)
        {

        }

        [Fact]
        public void Retrieves_all_for_administrator()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateAdministratorController(scope);

            // Act
            var result = ((ObjectResult)controller.GetPaged(0, 0).Result)?.Value as PagedResult<EncounterDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(9);
            result.TotalCount.ShouldBe(9);
        }

        [Fact]
        public void Retrieves_one()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateAdministratorController(scope);

            // Act
            var result = ((ObjectResult)controller.Get(-1).Result)?.Value as EncounterDto;

            // Assert
            result.ShouldNotBeNull();
        }

        [Fact]
        public void Retrieves_all_public_for_tourist()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateTouristController(scope);

            // Act
            var result = ((ObjectResult)controller.GetAllPublic().Result)?.Value as PagedResult<EncounterDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(6);
            result.TotalCount.ShouldBe(6);
        }

        [Fact]
        public void Retrieves_all_by_keypoints_for_tourist()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateTouristController(scope);

            // Act
            var result = ((ObjectResult)controller.GetAllByKeyPointIds(new List<long> { -1, -2 }).Result)?.Value as PagedResult<EncounterDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(2);
            result.TotalCount.ShouldBe(2);
        }

        private static Explorer.API.Controllers.Administrator.EncounterController CreateAdministratorController(IServiceScope scope)
        {
            return new Explorer.API.Controllers.Administrator.EncounterController(scope.ServiceProvider.GetRequiredService<IEncounterService>())
            {
                ControllerContext = BuildEncounterContext("-1")
            };
        }

        private static Explorer.API.Controllers.Author.EncounterController CreateAuthorController(IServiceScope scope)
        {
            return new Explorer.API.Controllers.Author.EncounterController(scope.ServiceProvider.GetRequiredService<IEncounterService>())
            {
                ControllerContext = BuildEncounterContext("-11")
            };
        }

        private static Explorer.API.Controllers.Tourist.EncounterController CreateTouristController(IServiceScope scope)
        {
            return new Explorer.API.Controllers.Tourist.EncounterController(scope.ServiceProvider.GetRequiredService<IEncounterService>(), scope.ServiceProvider.GetRequiredService<IEncounterExecutionService>())
            {
                ControllerContext = BuildEncounterContext("-21")
            };
        }
    }
}
