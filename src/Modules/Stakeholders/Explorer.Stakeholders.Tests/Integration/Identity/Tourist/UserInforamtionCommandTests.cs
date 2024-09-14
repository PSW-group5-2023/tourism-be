using Explorer.API.Controllers.Tourist;
using Explorer.Payments.API.Public;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Explorer.Stakeholders.Tests.Integration.Identity.Tourist
{
    [Collection("Sequential")]
    public class UserInforamtionCommandTests : BaseStakeholdersIntegrationTest
    {
        public UserInforamtionCommandTests(StakeholdersTestFactory fact) : base(fact) { }
        [Theory]
        [MemberData(nameof(Image))]
        public void Update(string image, int expectedResponsecode)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope, "-21");
            var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();

            // Act
            var result = (ObjectResult)controller.ChangeAvatarImage(image).Result;

            // Assert - Response
            result.StatusCode.ShouldBe(expectedResponsecode);
            result.ShouldNotBeNull();

            // Assert - Database
            var updatedEntity = dbContext.Users.Where(x => x.Id == -21).FirstOrDefault();
            updatedEntity.ShouldNotBeNull();
            updatedEntity.AvatarImage.ToString().ShouldBe(image);
        }
        public static IEnumerable<object[]> Image()
        {
            return new List<object[]>
            {
                new object[]
                {
                    "https://via-ventura.com/images/e86a00cc-7b12-4bfd-b70a-c81ece4d97a7.png",
                    200
                }
            };
        }
        
        private static UserInformationController CreateController(IServiceScope scope, string userId)
        {
            return new UserInformationController(scope.ServiceProvider.GetRequiredService<IUserInformationService>())
            {
                ControllerContext = BuildContext(userId)
            };
        }
    }
}
