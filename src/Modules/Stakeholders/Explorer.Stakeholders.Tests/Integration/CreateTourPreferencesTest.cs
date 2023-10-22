using Explorer.API.Controllers.Tourist;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Explorer.Stakeholders.Core.Domain;
using Shouldly;

namespace Explorer.Stakeholders.Tests.Integration
{
    [Collection("Sequential")]
    public class CreateTourPreferencesTest : BaseStakeholdersIntegrationTest
    {
        public CreateTourPreferencesTest(StakeholdersTestFactory factory) : base(factory) { }

        [Fact]
        public void Creates()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();
            var controller = CreateController(scope);
            var preferences = new TourPreferencesDto
            {
                Id = 3,
                UserId = -22,
                DifficultyLevel = 1,
                WalkingRate = 0,
                BicycleRate = 2,
                CarRate = 3,
                BoatRate = 1,
                Tags = new List<string> { "hiking", "boats" }
            };

            //Act
            var response = ((ObjectResult)controller.Create(preferences).Result)?.Value as TourPreferencesDto;

            //Assert - Response
            response.ShouldNotBeNull();
            response.Id.ShouldBe(3);


            //Assert - Database
            dbContext.ChangeTracker.Clear();
            var storedPreferences = dbContext.TourPreferences.FirstOrDefault(p => p.Id == preferences.Id);
            storedPreferences.ShouldNotBeNull();
            storedPreferences.UserId.ShouldBe(-22);
            storedPreferences.DifficultyLevel.ShouldBe(1);
            storedPreferences.WalkingRate.ShouldBe(0);
            storedPreferences.BicycleRate.ShouldBe(2);
            storedPreferences.CarRate.ShouldBe(3);
            storedPreferences.BoatRate.ShouldBe(1);
            storedPreferences.Tags.Count.ShouldBe(2);
        }

        private static TourPreferencesController CreateController(IServiceScope scope)
        {
            return new TourPreferencesController(scope.ServiceProvider.GetRequiredService<ITourPreferencesService>());
        }
    }
}
