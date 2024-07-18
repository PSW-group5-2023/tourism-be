using Explorer.API.Controllers.Tourist;
using Explorer.Tours.API.Dtos.Tour;
using Explorer.Tours.API.Public;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Explorer.Tours.Tests.Integration.TourExecution.Preferences
{
    [Collection("Sequential")]
    public class PreferencesQueryTests : BaseToursIntegrationTest
    {
        public PreferencesQueryTests(ToursTestFactory factory) : base(factory) { }

        [Fact]
        public void Retrieves_by_user_id()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.GetByUserId().Result)?.Value as PreferencesDto;

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(-1);
            result.UserId.ShouldBe(-21);
            result.DifficultyLevel.ShouldBe(1);
            result.WalkingRate.ShouldBe(1);
            result.BicycleRate.ShouldBe(1);
            result.CarRate.ShouldBe(1);
            result.BoatRate.ShouldBe(1);
        }

        private static PreferencesController CreateController(IServiceScope scope)
        {
            return new PreferencesController(scope.ServiceProvider.GetRequiredService<IPreferencesService>())
            {
                ControllerContext = BuildContext("-21")
            };
        }
    }
}
