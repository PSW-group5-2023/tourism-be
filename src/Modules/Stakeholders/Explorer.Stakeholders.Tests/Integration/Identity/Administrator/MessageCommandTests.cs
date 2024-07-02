using Explorer.API.Controllers.Administrator.Identity;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public.Identity;
using Explorer.Stakeholders.Infrastructure.Database;
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
    public class MessageCommandTests : BaseStakeholdersIntegrationTest
    {
        public MessageCommandTests(StakeholdersTestFactory factory) : base(factory) { }

        [Theory]
        [MemberData(nameof(MessageDto))]
        public void Create(MessageDto message, int expectedResponseCode)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();

            // Act
            var result = (ObjectResult)controller.Create(message).Result;

            // Assert - Response
            result.StatusCode.ShouldBe(expectedResponseCode);
            result.ShouldNotBeNull();

            // Assert - Database
            var storedEntity = dbContext.Messages.FirstOrDefault(m => m.Id == message.Id);
            storedEntity.ShouldNotBeNull();
        }

        [Theory]
        [MemberData(nameof(MessageDtoFail))]
        public void Create_fails_invaild_sender_id(MessageDto message, int expectedResponseCode)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.Create(message).Result;

            // Assert - Response
            result.StatusCode.ShouldBe(expectedResponseCode);
        }

        public static IEnumerable<object[]> MessageDto()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new MessageDto
                    {
                        Id = new Random().Next(int.MinValue, int.MaxValue),
                        Content = "content",
                        CreationTime = DateTime.Now.ToUniversalTime(),
                        SenderId = -1,
                        RecipientId = -11,
                        SenderUsername = "admin@gmail.com",
                        RecipientUsername = "author1@gmail.com"
                    },
                    200
                }
            };
        }

        public static IEnumerable<object[]> MessageDtoFail()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new MessageDto
                    {
                        Id = -11,
                        Content = "content",
                        CreationTime = DateTime.Now.ToUniversalTime(),
                        SenderId = -1000,
                        RecipientId = -11,
                        SenderUsername = "admin@gmail.com",
                        RecipientUsername = "author1@gmail.com"
                    },
                    400
                }
            };
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
