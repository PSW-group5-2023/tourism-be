using Explorer.API.Controllers.Tourist;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.API.Public.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Tests.Integration.Identity.Tourist
{
    [Collection("Sequential")]
    public class UserNewsQueryTests : BaseStakeholdersIntegrationTest
    {
        public UserNewsQueryTests(StakeholdersTestFactory fact) : base(fact) { }

        [Theory]
        [InlineData(-21, 200)]
        public void Get_by_tourist_id(int touristId, int expectedResponseCode)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.GetByTouristId(touristId).Result;

            // Assert
            result.StatusCode.ShouldBe(expectedResponseCode);
            result.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(-1000, 404)]
        public void Get_by_tourist_id_fails_invalid_id(int touristId, int expectedResponseCode)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.GetByTouristId(touristId).Result;

            // Assert
            result.StatusCode.ShouldBe(expectedResponseCode);
        }

        [Theory]
        [InlineData(-11, 200)]
        public void Get(int id, int expectedResponseCode)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.Get(id).Result;

            // Assert
            result.StatusCode.ShouldBe(expectedResponseCode);
            result.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(-1000, 404)]
        public void Get_fails_invalid_id(int id, int expectedResponseCode)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.Get(id).Result;

            // Assert
            result.StatusCode.ShouldBe(expectedResponseCode);
        }

        private static UserNewsController CreateController(IServiceScope scope)
        {
            return new UserNewsController(scope.ServiceProvider.GetRequiredService<IUserNewsService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
