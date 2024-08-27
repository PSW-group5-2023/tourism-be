using Explorer.API.Controllers.Tourist;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Tour;
using Explorer.Tours.API.Dtos.Tour.Tourist;
using Explorer.Tours.API.Internal;
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
    [Collection("Sequential")]
    public class TourQueryTests : BaseToursIntegrationTest
    {
        public TourQueryTests(ToursTestFactory factory) : base(factory) { }

        [Fact]
        public void Get_all()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.GetAll(0, 0).Result)?.Value as PagedResult<TourDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(15);
            result.TotalCount.ShouldBe(15);
        }

        [Fact]
        public void Retrieves_all_mobile()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.GetAllMobile(0, 0).Result)?.Value as PagedResult<TourMobileDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(3);
            result.TotalCount.ShouldBe(3);
        }

        [Fact]
        public void Retrieves_all_mobile_sorted_by_latest()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.GetAllSortedByLatestMobile(0, 0).Result)?.Value as PagedResult<TourMobileDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(3);
            result.TotalCount.ShouldBe(3);
        }
        [Fact]
        public void Retrieves_all_mobile_filtered_by_location()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.GetAllFilterByLocationMobile(0, 0,10, 24.209304098892062, 12.332725774649834).Result)?.Value as PagedResult<TourMobileDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(1);
            result.TotalCount.ShouldBe(1);
        }
        [Fact]
        public void Retrieves_all_mobile_filtered_by_rating()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.GetAllFilterByRatingMobile(0, 0, 4).Result)?.Value as PagedResult<TourMobileDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(1);
            result.TotalCount.ShouldBe(1);
        }

        [Fact]
        public void Retrieves_all_mobile_sorted_by_popular()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.GetAllSortedByPopularMobile(0, 0).Result)?.Value as PagedResult<TourMobileDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(3);
            result.TotalCount.ShouldBe(3);
        }

        [Fact]
        public void Get()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.Get(-1).Result)?.Value as TourDto;

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
            var result = ((ObjectResult)controller.GetMobile(-1).Result)?.Value as TourMobileDto;

            // Assert
            result.ShouldNotBeNull();
        }

        [Fact]
        public void Get_fails_invalid_id()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.Get(-1000).Result;

            // Assert
            result.StatusCode.ShouldBe(404);
        }

        [Theory]
        [InlineData(0, 0, "tura 1", new string[] { "tag", "tag2" }, 200)]
        public void Search(int page, int pageSize, string name, string[] tags, int expectedResultCode)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.Search(page, pageSize, name, tags).Result;

            // Assert
            result.StatusCode.ShouldBe(expectedResultCode);
            (result.Value as PagedResult<TourDto>).Results.Count.ShouldBe(7);
            (result.Value as PagedResult<TourDto>).TotalCount.ShouldBe(7);
        }

        private static TourController CreateController(IServiceScope scope)
        {
            return new TourController(scope.ServiceProvider.GetRequiredService<ITourService>(), scope.ServiceProvider.GetRequiredService<IRecommenderService>())
            {
                ControllerContext = BuildContext("-1")
            };

        }
    }
}
