using Explorer.API.Controllers.Administrator.Administration;
using Explorer.API.Controllers.Tourist;
using Explorer.Blog.API.Dtos;
using Explorer.Blog.API.Public;
using Explorer.Blog.Infrastructure.Database;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
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
    public class BlogCreationTests : BaseBlogIntegrationTest
    {
        public BlogCreationTests(BlogTestFactory factory) : base(factory) { }

        [Fact]
        public void Creates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<BlogContext>();
            var newEntity = new BlogDto
            {
                Id = -5,
                Title = "Title 006",
                Description = "Description 1",
                Status = BlogState.Published
            };

            // Act
            var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as BlogDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.Title.ShouldBe(newEntity.Title);
            result.Description.ShouldBe(newEntity.Description);
            result.Status.ShouldBe(newEntity.Status);
            // Assert - Database
            var storedEntity = dbContext.Blogs.FirstOrDefault(i => i.Id == newEntity.Id);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(result.Id);
            storedEntity.Title.ShouldBe(result.Title);
            storedEntity.Description.ShouldBe(result.Description);
            storedEntity.Status.ShouldBe(result.Status);
        }


        [Fact]
        public void Create_fails_invalid_data()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var updatedEntity = new BlogDto
            {
                Description = "Test"
            };

            // Act
            var result = (ObjectResult)controller.Create(updatedEntity).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(400);
        }

        [Fact]
        public void Retrieves_all()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.GetAll().Result)?.Value as PagedResult<BlogDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(5);
            result.TotalCount.ShouldBe(5);
        }


        private static BlogController CreateController(IServiceScope scope)
        {
            return new BlogController(scope.ServiceProvider.GetRequiredService<IBlogService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
