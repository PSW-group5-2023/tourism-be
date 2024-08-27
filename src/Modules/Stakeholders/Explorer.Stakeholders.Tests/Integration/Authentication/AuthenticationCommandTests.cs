using Explorer.Achievements.API.Public;
using Explorer.API.Controllers;
using Explorer.Encounters.API.Public;
using Explorer.Payments.API.Public;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Tests.Integration.Authentication
{
    [Collection("Sequential")]
    public class AuthenticationCommandTests : BaseStakeholdersIntegrationTest
    {
        public AuthenticationCommandTests(StakeholdersTestFactory factory) : base(factory) { }

        [Theory]
        [MemberData(nameof(AccountRegistrationDto))]
        public void Register_tourist(AccountRegistrationDto account, int expectedResponseCode)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.RegisterTourist(account).Result;
            

            // Assert - Response
            result.StatusCode.ShouldBe(expectedResponseCode);

            var authenticationResponse = result.Value as RegisteredUserDto;
            authenticationResponse.ShouldNotBeNull();
            //var personId = decodedAccessToken.Claims.FirstOrDefault(c => c.Type == "personId");
            //personId.ShouldNotBeNull();
            //personId.Value.ShouldNotBe("0");

            // Assert - Database
            dbContext.ChangeTracker.Clear();
            var storedAccount = dbContext.Users.FirstOrDefault(u => u.Username == account.Email);
            storedAccount.ShouldNotBeNull();
            storedAccount.Role.ShouldBe(UserRole.Tourist);
        }

        [Theory]
        [MemberData(nameof(AccountRegistrationFailed))]
        public void Register_tourist_fails(AccountRegistrationDto account, int expectedResponseCode)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.RegisterTourist(account).Result;

            // Assert - Response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(expectedResponseCode);

            //Assert - Database
            var storedAccount = dbContext.Users.FirstOrDefault(u => u.Username == account.Email && u.Password == account.Password);
            storedAccount.ShouldBeNull();
        }

        [Theory]
        [MemberData(nameof(MobileRegistrationDto))]
        public void Register_guest(AccountMobileDto account, int expectedResponseCode)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.RegisterGuest(account).Result;


            // Assert - Response
            result.StatusCode.ShouldBe(expectedResponseCode);

            var authenticationResponse = result.Value as AuthenticationTokensDto;
            authenticationResponse.ShouldNotBeNull();
            authenticationResponse.Id.ShouldNotBe(0);
            var decodedAccessToken = new JwtSecurityTokenHandler().ReadJwtToken(authenticationResponse.AccessToken);


            // Assert - Database
            dbContext.ChangeTracker.Clear();
            var storedAccount = dbContext.Users.FirstOrDefault(u => u.Username == account.Username);
            storedAccount.ShouldNotBeNull();
            storedAccount.Role.ShouldBe(UserRole.Guest);
        }

        [Theory]
        [MemberData(nameof(MobileRegistrationFailed))]
        public void Register_guest_fails(AccountMobileDto account, int expectedResponseCode)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.RegisterGuest(account).Result;

            // Assert - Response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(expectedResponseCode);

            //Assert - Database
            var storedAccount = dbContext.Users.FirstOrDefault(u => u.Username == account.Username);
            storedAccount.ShouldNotBeNull();
        }
        public static IEnumerable<object[]> AccountRegistrationDto()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new AccountRegistrationDto
                    {
                        Username = "turistaA@gmail.com",
                        Email = "turistaA@gmail.com",
                        Password = "turistaA",
                        //Name = "Žika",
                        //Surname = "Žikić"
                    },
                    200
                }
            };
        }

        public static IEnumerable<object[]> AccountRegistrationFailed()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new AccountRegistrationDto
                    {
                        Username = "turista2@gmail.com",
                        Email = "turista2@gmail.com",
                        Password = "turistaB",
                        //Name = "ŽikaB",
                        //Surname = "ŽikićB"
                    },
                    400
                }
            };
        }

        public static IEnumerable<object[]> MobileRegistrationDto()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new AccountMobileDto
                    {
                        Username = "guestA@gmail.com"
                    },
                    200
                }
            };
        }

        public static IEnumerable<object[]> MobileRegistrationFailed()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new AccountMobileDto
                    {
                        Username = "autor3@gmail.com",
                    },
                    400
                }
            };
        }

        private static AuthenticationController CreateController(IServiceScope scope)
        {
            return new AuthenticationController(scope.ServiceProvider.GetRequiredService<IAuthenticationService>(), scope.ServiceProvider.GetRequiredService<IWalletService>(), scope.ServiceProvider.GetRequiredService<IUserExperienceService>(), scope.ServiceProvider.GetRequiredService<IInventoryService>());
        }
    }    
}
