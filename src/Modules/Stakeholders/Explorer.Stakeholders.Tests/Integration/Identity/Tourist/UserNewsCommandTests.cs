using Explorer.API.Controllers.Tourist;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Infrastructure.Database;
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
    public class UserNewsCommandTests : BaseStakeholdersIntegrationTest
    {
        public UserNewsCommandTests(StakeholdersTestFactory fact) : base(fact) { }

        [Theory]
        [MemberData(nameof(UserNewsDto))]
        public void Create(UserNewsDto userNews, int expectedResponsecode)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();

            // Act
            var result = (ObjectResult)controller.Create(userNews).Result;

            // Assert - Response
            result.StatusCode.ShouldBe(expectedResponsecode);
            result.ShouldNotBeNull();

            // Assert - Database
            var storedEntity = dbContext.UserNews.FirstOrDefault(u => u.Id == userNews.Id);
            storedEntity.ShouldNotBeNull();
        }

        [Theory]
        [MemberData(nameof(UserNewsDtoFail))]
        public void Create_fails_invalid_tourist_id(UserNewsDto userNews, int expectedResponsecode)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (BadRequestResult)controller.Create(userNews).Result;

            // Assert - Response
            result.StatusCode.ShouldBe(expectedResponsecode);
        }

        [Theory]
        [MemberData(nameof(UserNewsDtoUpdate))]
        public void Update(UserNewsDto userNews, int expectedResponsecode)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();

            // Act
            var result = (ObjectResult)controller.Update(userNews).Result;

            // Assert - Response
            result.StatusCode.ShouldBe(expectedResponsecode);
            result.ShouldNotBeNull();

            // Assert - Database
            var updatedEntity = dbContext.UserNews.FirstOrDefault(u => u.Id == userNews.Id);
            updatedEntity.ShouldNotBeNull();
            updatedEntity.SendingPeriod.ShouldBe(0);
        }

        [Theory]
        [MemberData(nameof(UserNewsDtoUpdateFail))]
        public void Update_fails_invalid_user_news_id(UserNewsDto userNews, int expectedResponsecode)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.Update(userNews).Result;

            // Assert - Response
            result.StatusCode.ShouldBe(expectedResponsecode);
        }

        public static IEnumerable<object[]> UserNewsDto()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new UserNewsDto
                    (
                        -1,
                        -23,
                        10,
                        320000
                    ),
                    200
                }
            };
        }

        public static IEnumerable<object[]> UserNewsDtoFail()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new UserNewsDto
                    {
                        Id = 1,
                        TouristId = 0,
                        LastSendMs = 10,
                        SendingPeriod = 32000,
                    },
                    400
                }
            };
        }

        public static IEnumerable<object[]> UserNewsDtoUpdate()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new UserNewsDto
                    (
                        -11,
                        -21,
                        10,
                        0
                    ),
                    200
                }
            };
        }

        public static IEnumerable<object[]> UserNewsDtoUpdateFail()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new UserNewsDto
                    (
                        -1,
                        -21,
                        10,
                        0
                    ),
                    404
                }
            };
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
