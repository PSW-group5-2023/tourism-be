﻿using Explorer.API.Controllers.Tourist;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Facility;
using Explorer.Tours.API.Public.Facility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Explorer.Tours.Tests.Integration.Administration.Facility
{
    [Collection("Sequential")]
    public class FacilityQueryTests : BaseToursIntegrationTest
    {
        public FacilityQueryTests(ToursTestFactory factory) : base(factory) { }
        [Fact]
        public void Retrieves_all()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.GetAll(0, 0).Result)?.Value as PagedResult<FacilityDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(4);
            result.TotalCount.ShouldBe(4);
        }

        private static FacilityController CreateController(IServiceScope scope)
        {
            return new FacilityController(scope.ServiceProvider.GetRequiredService<IFacilityService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
