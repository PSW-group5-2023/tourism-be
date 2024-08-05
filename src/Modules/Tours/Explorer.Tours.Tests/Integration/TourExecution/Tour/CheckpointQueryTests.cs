using Explorer.API.Controllers.Tourist;
using Explorer.Tours.API.Dtos.Tour.Tourist;
using Explorer.Tours.API.Public.Tour;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Tests.Integration.TourExecution.Tour
{
    public class CheckpointQueryTests : BaseToursIntegrationTest
    {
        public CheckpointQueryTests(ToursTestFactory factory) : base(factory)
        {
        }

        [Fact]
        public void Retrieves_checkpoints_by_tourId_mobile()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.GetByTourIdMobile(-1).Result;

            // Assert
            result.ShouldNotBeNull();
        }

        [Fact]
        public void Retrieves_one_mobile()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.GetByCheckpointIdMobile(-1).Result;

            // Assert
            result.ShouldNotBeNull();
        }

        private static CheckpointController CreateController(IServiceScope scope)
        {
            return new CheckpointController(scope.ServiceProvider.GetRequiredService<ICheckpointService>(), scope.ServiceProvider.GetRequiredService<IPublicCheckpointService>())
            {
                ControllerContext = BuildContext("-1")
            };

        }
    }
}
