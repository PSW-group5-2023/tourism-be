using Explorer.API.Controllers.Administrator.Identity;
using Explorer.Stakeholders.API.Public.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Tests.Integration.Identity.Administrator
{
    [Collection("Sequential")]
    public class MessageQueryTests : BaseStakeholdersIntegrationTest
    {
        public MessageQueryTests(StakeholdersTestFactory factory) : base(factory) { }

        [Fact]
        public void Get_all()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.GetAll(0, 0).Result;

            // Assert
            result.StatusCode.ShouldBe(200);
            result.ShouldNotBeNull();

        }
        private static MessageController CreateController(IServiceScope scope)
        {
            return new MessageController(scope.ServiceProvider.GetRequiredService<IMessageService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
