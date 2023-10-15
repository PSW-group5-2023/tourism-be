using Explorer.API.Controllers.Tourist;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Tests.Integration
{
    [Collection("Sequential")]
    public class TourRatingCommandTests : BaseToursIntegrationTest
    {
        public TourRatingCommandTests(ToursTestFactory factory) : base(factory) { }

        [Fact]
        public void Creates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();
            var newEntity = new TourRatingDto
            {
                UserId = 1,
                Mark = 4,
                Comment = "Bilo je veoma dobro",
                DateOfVisit = DateTime.Now
            };

            // Act
            var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as TourRatingDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.UserId.ShouldNotBe(0);
            result.Comment.ShouldBe(newEntity.Comment);

            // Assert - Database
            var storedEntity = dbContext.TourRatings.FirstOrDefault(i => i.Comment == newEntity.Comment);
            storedEntity.ShouldNotBeNull();
        }

        private static TourRatingController CreateController(IServiceScope scope)
        {
            return new TourRatingController(scope.ServiceProvider.GetRequiredService<ITourRatingService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
