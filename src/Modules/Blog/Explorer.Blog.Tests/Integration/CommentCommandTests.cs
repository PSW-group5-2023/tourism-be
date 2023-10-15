using Explorer.API.Controllers.Tourist;
using Explorer.Blog.API.Dtos;
using Explorer.Blog.API.Public;
using Explorer.Blog.Infrastructure.Database;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Blog.Tests.Integration
{
    [Collection("Sequential")]
    public class CommentCommandTests : BaseBlogIntegrationTest
    {
        public CommentCommandTests(BlogTestFactory factory) : base(factory)
        {
        }

        [Fact]
        public void Creates()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<BlogContext>();
            var newEntity = new CommentDto
            {
                Username = "username3",
                CreationDate = DateTime.UtcNow,
                Description = "ovo je prvi komentar ikada",
                LastEditDate = DateTime.UtcNow,
                BlogId = 1
            };

            //Act
            var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as CommentDto;

            //Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.Username.ShouldBe(newEntity.Username);

            //Assert - Database
            var storedEntity = dbContext.Comments.FirstOrDefault(i => i.Username ==  newEntity.Username);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(result.Id);
        }

        [Fact]
        public void Create_fails_invalid_data()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var updatedEntity = new CommentDto
            {
                Description = "Test"
            };

            //Act
            var result = (ObjectResult)controller.Create(updatedEntity).Result;

            //Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(400);
        }

        [Fact]
        public void Updates()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<BlogContext>();
            var updatedEntity = new CommentDto
            {
                Id = -1,
                Username = "username",
                CreationDate = DateTime.UtcNow,
                Description = "ovo je prvi edit ikada",
                LastEditDate = DateTime.UtcNow,
                BlogId = 1
            };

            //Act
            var result = ((ObjectResult)controller.Update(updatedEntity).Result)?.Value as CommentDto;

            //Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldBe(-1);
            result.Username.ShouldBe(updatedEntity.Username);
            result.Description.ShouldBe(updatedEntity.Description);

            //Assert
            var storedEntity = dbContext.Comments.FirstOrDefault(i => i.Username == "username");
            storedEntity.ShouldNotBeNull();
            storedEntity.Description.ShouldBe(updatedEntity.Description);
        }

        [Fact]
        public void Update_fails_invalid_id()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var updatedEntity = new CommentDto
            {
                Id = -1000,
                Username = "Test"
            };

            //Act
            var result = (ObjectResult)controller.Update(updatedEntity).Result;

            //Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(400);
        }

        private static CommentController CreateController(IServiceScope scope)
        {
            return new CommentController(scope.ServiceProvider.GetRequiredService<ICommentService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
