using Explorer.API.Controllers.Administrator.Administration;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public;
using Explorer.Payments.Infrastructure.Database;
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

namespace Explorer.Payments.Tests.Integration.Wallet
{
    public class WalletCommandTests : BasePaymentsIntegrationTest
    {
        public WalletCommandTests(PaymentsTestFactory factory) : base(factory)
        {
        }

        [Theory]
        [InlineData(-22, 200)]
        public void Add_to_balance(int userId, int coins)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<PaymentsContext>();

            // Act
            var result = ((ObjectResult)controller.AddToBalance(userId, coins).Result)?.Value as WalletDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.UserId.ShouldBe(userId);
            result.Balance.ShouldBe(coins + 40);

            // Assert - Database
            var storedEntity = dbContext.Wallet.FirstOrDefault(w => w.UserId == userId);
            storedEntity.ShouldNotBeNull();
            storedEntity.Balance.ShouldBe(coins + 40);
        }

        [Theory]
        [InlineData(-1000, 200)]
        public void Add_to_balance_fails_invaild_userId(int userId, int coins)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.AddToBalance(userId, coins).Result;

            // Assert - Response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(404);

        }

        private static UserInformationController CreateController(IServiceScope scope)
        {
            return new UserInformationController(scope.ServiceProvider.GetRequiredService<IUserInformationService>(), scope.ServiceProvider.GetRequiredService<IPersonInformationService>(), scope.ServiceProvider.GetRequiredService<IUserActivityService>(), scope.ServiceProvider.GetRequiredService<IWalletService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }

    }
}
