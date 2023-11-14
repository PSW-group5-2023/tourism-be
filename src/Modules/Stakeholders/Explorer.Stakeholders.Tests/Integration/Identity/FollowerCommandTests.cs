using Explorer.API.Controllers.Tourist.Identity;
using Explorer.API.Controllers.Execution;
using Explorer.Stakeholders.API.Public.Identity;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Execution;
using Explorer.Tours.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.Stakeholders.API.Dtos;
using Shouldly;
using Explorer.Stakeholders.Infrastructure.Database;

namespace Explorer.Stakeholders.Tests.Integration.Identity
{
    [Collection("Sequential")]
    public class FollowerCommandTests : BaseStakeholdersIntegrationTest
    {
        public FollowerCommandTests(StakeholdersTestFactory factory) : base(factory)
        {

        }

        [Theory]
        [MemberData(nameof(FollowerDto))]
        public void Create_session(FollowerDto follower, int expectedResponseCode)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();

            var result = (ObjectResult)controller.Create(follower).Result;

            result.StatusCode.ShouldBe(expectedResponseCode);

            // Assert - Database
            var storedEntity = dbContext.Followers.FirstOrDefault(t => t.Id == follower.Id);
            storedEntity.ShouldNotBeNull();
        }
        public static IEnumerable<object[]> FollowerDto()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new FollowerDto
                    {
                        Id = -1,
                        
                    },
                    200
                }
            };
        }

        private static FollowerController CreateController(IServiceScope scope)
        {
            return new FollowerController(scope.ServiceProvider.GetRequiredService<IFollowerService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
