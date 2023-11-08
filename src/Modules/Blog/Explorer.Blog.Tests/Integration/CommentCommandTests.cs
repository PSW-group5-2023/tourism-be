using Explorer.API.Controllers.Tourist;
using Explorer.Blog.API.Dtos;
using Explorer.Blog.API.Public;
using Explorer.Blog.Infrastructure.Database;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.Infrastructure.Database;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
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

        [Theory]
        [MemberData(nameof(CommentDtos))]
        public void Creation(CommentDto commentDto, int expectedResponseCode)
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<BlogContext>();

            var result = (ObjectResult)controller.Create(commentDto).Result;

            //Assert - Response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(expectedResponseCode);

            //Assert - Database
            if (result.StatusCode != 400)
            {
                var storedEntity = dbContext.Comments.FirstOrDefault(t => t.Id == commentDto.Id);
                storedEntity.ShouldNotBeNull();
            }
        }

        public static IEnumerable<object[]> CommentDtos()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new CommentDto
                    {
                        Id = -4,
                        CreationDate = DateTime.UtcNow,
                        UserId = -11,
                        ProfilePic = new Uri("https://images.rawpixel.com/image_png_800/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIzLTAxL3JtNjA5LXNvbGlkaWNvbi13LTAwMi1wLnBuZw.png"),
                        Description = "opis -4 hihihiha",
                        LastEditDate = DateTime.UtcNow,
                        BlogId = -21
                    },
                    200
                }
            };
        }

        public static IEnumerable<object[]> CommentDtos2()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new CommentDto
                    {
                        Id = -3,
                        CreationDate = DateTime.UtcNow,
                        UserId = -11,
                        ProfilePic = new Uri("https://images.rawpixel.com/image_png_800/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIzLTAxL3JtNjA5LXNvbGlkaWNvbi13LTAwMi1wLnBuZw.png"),
                        Description = "opis -4 hihihiha",
                        LastEditDate = DateTime.UtcNow,
                        BlogId = -21
                    },
                    200
                }
            };
        }

        [Theory]
        [MemberData(nameof(CommentDtos2))]
        public void UpdateComment(CommentDto commentDto, int expectedResponseCode)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<BlogContext>();

            var result = (ObjectResult)controller.UpdateComment(commentDto).Result;

            // Assert - Response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(expectedResponseCode);

            // Assert - Database
            var storedEntity = dbContext.Comments.FirstOrDefault(t => t.Id == commentDto.Id);
            storedEntity.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(-3, 200)]
        [InlineData(-5, 404)]
        public void DeleteComment(int commentId, int expectedResponseCode)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<BlogContext>();

            var result = (OkResult)controller.DeleteComment(commentId);

            // Assert - Response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(expectedResponseCode);

            //Assert - Database
            var storedEntity = dbContext.Comments.FirstOrDefault(t => t.Id == commentId);
            storedEntity.ShouldBeNull();
        }

        /*[Theory]
        [InlineData(-21, 200)]
        public void GetCommentsByBlogId(int blogId, int expectedResponseCode)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<BlogContext>();

            var result = (ObjectResult)controller.GetCommentsByBlogId(blogId).Result;

            // Assert - Database
            var storedEntity = dbContext.Comments.FirstOrDefault(c => c.BlogId == blogId);
            storedEntity.ShouldNotBeNull();
        }*/

        private static BlogController CreateController(IServiceScope scope)
        {
            return new BlogController(scope.ServiceProvider.GetRequiredService<IBlogService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
        /*
        [Fact]
        public void Creates()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<BlogContext>();
            var newEntity = new CommentDto
            {
                UserId = -11,
                CreationDate = DateTime.UtcNow,
                Description = "ovo je prvi komentar ikada",
                LastEditDate = DateTime.UtcNow,
                BlogId = -21
            };

            //Act
            var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as CommentDto;

            //Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.Description.ShouldBe(newEntity.Description);

            //Assert - Database
            var storedEntity = dbContext.Comments.FirstOrDefault(i => i.Id == result.Id);
            storedEntity.ShouldNotBeNull();
        }

        [Fact]
        public void Create_fails_invalid_data()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var updatedEntity = new CommentDto
            {
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
                UserId = -1,
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
            result.Description.ShouldBe(updatedEntity.Description);

            //Assert
            var storedEntity = dbContext.Comments.FirstOrDefault(i => i.UserId == -1);
            storedEntity.ShouldNotBeNull();
            storedEntity.Description.ShouldBe(updatedEntity.Description);
            var oldEntity = dbContext.Comments.FirstOrDefault(i => i.Description == "ovo je prvi komentar ikad");
            oldEntity.ShouldBeNull();
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
                UserId = -1
            };

            //Act
            var result = (ObjectResult)controller.Update(updatedEntity).Result;

            //Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(400);
        }

        [Fact]
        public void Get()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            //Act
            var result = ((ObjectResult)controller.Get(-2).Result)?.Value as CommentDto;

            //Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(-2);
        }

        [Fact]
        public void Get_by_id_fails_invalid_id()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            //Act
            var result = (ObjectResult)controller.Get(-100).Result;

            //Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(404);
        }

        private static CommentController CreateController(IServiceScope scope)
        {
            return new CommentController(scope.ServiceProvider.GetRequiredService<ICommentService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }*/
    }
}
