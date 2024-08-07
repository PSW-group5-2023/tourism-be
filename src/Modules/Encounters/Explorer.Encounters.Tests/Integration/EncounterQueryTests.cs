﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
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
            var controller = CreateAdministratorController(scope, "-1");

            // Act
            var result = ((ObjectResult)controller.GetPaged(0, 0).Result)?.Value as PagedResult<EncounterDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(11);
            result.TotalCount.ShouldBe(11);
        }

        [Fact]
        public void Retrieves_one()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateAdministratorController(scope, "-1");

            // Act
            var result = ((ObjectResult)controller.Get(-10).Result)?.Value as EncounterDto;

            // Assert
            result.ShouldNotBeNull();
        }

        [Fact]
        public void Retrieves_all_public_for_tourist()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateTouristController(scope, "-21");

            // Act
            var result = ((ObjectResult)controller.GetAllPublic().Result)?.Value as PagedResult<EncounterDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(6);
            result.TotalCount.ShouldBe(6);
        }

        [Fact]
        public void Retrieves_all_by_checkpoints_for_tourist()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateTouristController(scope, "-21");

            // Act
            var result = ((ObjectResult)controller.GetAllByCheckpointIds(new List<long> { -1, -2 }).Result)?.Value as PagedResult<EncounterDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(3);
            result.TotalCount.ShouldBe(3);
        }
       

        private static Explorer.API.Controllers.Administrator.EncounterController CreateAdministratorController(IServiceScope scope, string userId)
        {
            return new Explorer.API.Controllers.Administrator.EncounterController(scope.ServiceProvider.GetRequiredService<IEncounterService>())
            {
                ControllerContext = BuildEncounterContext(userId)
            };
        }

        private static Explorer.API.Controllers.Author.EncounterController CreateAuthorController(IServiceScope scope, string userId)
        {
            return new Explorer.API.Controllers.Author.EncounterController(scope.ServiceProvider.GetRequiredService<IEncounterService>())
            {
                ControllerContext = BuildEncounterContext(userId)
            };
        }

        private static Explorer.API.Controllers.Tourist.EncounterController CreateTouristController(IServiceScope scope, string userId)
        {
            return new Explorer.API.Controllers.Tourist.EncounterController(scope.ServiceProvider.GetRequiredService<IEncounterService>(), scope.ServiceProvider.GetRequiredService<IQuestionService>())
            {
                ControllerContext = BuildEncounterContext(userId)
            };
        }
    }
}
