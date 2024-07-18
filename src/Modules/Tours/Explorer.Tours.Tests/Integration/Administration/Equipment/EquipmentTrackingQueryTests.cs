using Explorer.API.Controllers.Tourist;
using Explorer.Tours.API.Dtos.Equipment;
using Explorer.Tours.API.Public.Equipment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Explorer.Tours.Tests.Integration.Administration.Equipment
{
    [Collection("Sequential")]
    public class EquipmentTrackingQueryTests : BaseToursIntegrationTest
    {
        public EquipmentTrackingQueryTests(ToursTestFactory factory) : base(factory)
        {

        }

        [Fact]
        public void Retrieves_by_tourist_id()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.GetByTouristId().Result)?.Value as EquipmentTrackingDto;

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(-1);
        }

        private static EquipmentTrackingController CreateController(IServiceScope scope)
        {
            return new EquipmentTrackingController(scope.ServiceProvider.GetRequiredService<IEquipmentTrackingService>(), scope.ServiceProvider.GetRequiredService<IEquipmentService>())
            {
                ControllerContext = BuildContext("-21")
            };
        }
    }
}
