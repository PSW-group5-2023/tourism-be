using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Dtos.Tourist;
using Explorer.Encounters.API.Public;
using FluentResults;
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
    public class QuestionQueryTests: BaseEncountersIntegrationTest
    {
        public QuestionQueryTests(EncountersTestFactory factory) : base(factory)
        {

        }
        [Fact]
        public void Get_all_by_checkpointId()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateTouristController(scope, "-21");
            int checkpointId = -3;

            // Act
            var result = (ObjectResult)controller.GetByCheckpointTourist(checkpointId).Result;

            // Assert
            result.Value.ShouldNotBeNull();
            result.StatusCode.ShouldBe(200);

            if (result.Value is EncounterModuleQuizAchievementMobileDto dto)
            {
                Assert.NotNull(dto.Questions); 
                Assert.Equal(3, dto.Questions.Count); 
            }
            else
            {
                Assert.Fail("Unexpected result type returned.");
            }
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
