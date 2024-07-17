using Explorer.API.Controllers.Tourist;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Tour;
using Explorer.Tours.API.Public.Tour;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Tests.Integration.TourAuthoring.Tourist
{
    [Collection("Sequential")]
    public class TouristTourQueryTests : BaseToursIntegrationTest
    {
        public TouristTourQueryTests(ToursTestFactory factory) : base(factory)
        {

        }

        [Fact]
        public void Get()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.Get(-1).Result;

            // Assert
            result.StatusCode.ShouldBe(200);
            (result.Value as TourDto).ShouldNotBeNull();
        }

        [Fact]
        public void Get_invalid_id()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.Get(-1000000).Result;

            // Assert
            result.StatusCode.ShouldBe(404);
            (result.Value as TourDto).ShouldBeNull();
        }


        [Fact]
        public void Get_all_by_authorId()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.GetAllByAuthorId(-11, 0, 0).Result)?.Value as PagedResult<TourDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(3);
            result.TotalCount.ShouldBe(3);
        }

        [Fact]
        public void Get_all_by_authorId_fails_invalid_authorId()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.GetAllByAuthorId(-1000000, 0, 0).Result;

            // Assert
            //result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(400);
        }


        private static TouristTourController CreateController(IServiceScope scope)
        {
            return new TouristTourController(scope.ServiceProvider.GetRequiredService<ITourService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
