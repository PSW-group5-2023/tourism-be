using Explorer.Achievements.API.Public;
using Explorer.API.Controllers;
using Explorer.Encounters.API.Public;
using Explorer.Payments.API.Public;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
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
    public class AuthenticationQueryTests : BaseStakeholdersIntegrationTest
    {
        public AuthenticationQueryTests(StakeholdersTestFactory factory) : base(factory) { }

        [Fact]
        public void Login()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var loginSubmission = new CredentialsDto { Username = "turista1@gmail.com", Password = "turista1" };

            // Act
            var authenticationResponse = ((ObjectResult)controller.Login(loginSubmission).Result).Value as AuthenticationTokensDto;

            // Assert
            authenticationResponse.ShouldNotBeNull();
            authenticationResponse.Id.ShouldBe(-21);
            var decodedAccessToken = new JwtSecurityTokenHandler().ReadJwtToken(authenticationResponse.AccessToken);
            var personId = decodedAccessToken.Claims.FirstOrDefault(c => c.Type == "personId");
            personId.ShouldNotBeNull();
            personId.Value.ShouldBe("-21");
        }

        [Fact]
        public void Login_fails_not_registered_user()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var loginSubmission = new CredentialsDto { Username = "turistaY@gmail.com", Password = "turista1" };

            // Act
            var result = (ObjectResult)controller.Login(loginSubmission).Result;

            // Assert
            result.StatusCode.ShouldBe(404);
        }

        [Fact]
        public void Login_fails_invalid_password()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var loginSubmission = new CredentialsDto { Username = "turista3@gmail.com", Password = "123" };

            // Act
            var result = (ObjectResult)controller.Login(loginSubmission).Result;

            // Assert
            result.StatusCode.ShouldBe(404);
        }

        [Theory]
        [InlineData("turista1@gmail.com", 200)]
        public void Change_password_request(string email, int expectedResponseCode)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.ChangePasswordRequest(email).Result;

            // Assert
            result.StatusCode.ShouldBe(expectedResponseCode);
            result.Value.ShouldNotBeNull();
        }

        [Theory]
        [InlineData("turista100@gmail.com", 400)]
        public void Change_password_request_fails_email_doesnt_exist(string email, int expectedResponseCode)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.ChangePasswordRequest(email).Result;

            // Assert
            result.StatusCode.ShouldBe(expectedResponseCode);
            result.Value.ShouldNotBeNull();
        }

        private static AuthenticationController CreateController(IServiceScope scope)
        {
            return new AuthenticationController(scope.ServiceProvider.GetRequiredService<IAuthenticationService>(), scope.ServiceProvider.GetRequiredService<IWalletService>(), scope.ServiceProvider.GetRequiredService<IUserExperienceService>(), scope.ServiceProvider.GetRequiredService<IInventoryService>());
        }
    }
}
