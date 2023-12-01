using Explorer.API.Controllers.Author;
using Explorer.Blog.API.Dtos;
using Explorer.Blog.API.Public;
using Explorer.Blog.Infrastructure.Database;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public;
using Explorer.Payments.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.Tests.Integration
{
    [Collection("Sequential")]
    public class BundleCommandTests : BasePaymentsIntegrationTest
    {
        public BundleCommandTests(PaymentsTestFactory factory) : base(factory)
        {
        }

        [Theory]
        [MemberData(nameof(BundleCreateDtos))]
        public void Creation(BundleDto bundleDto, int expectedResponseCode)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<PaymentsContext>();

            var result = (ObjectResult)controller.Create(bundleDto).Result;

            // Assert - Response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(expectedResponseCode);

            // Assert - Database

            if (result.StatusCode != 400)
            {
                var storedEntity = dbContext.Bundles.FirstOrDefault(t => t.Id == bundleDto.Id);
                storedEntity.ShouldNotBeNull();
            }
        }
        public static IEnumerable<object[]> BundleCreateDtos()
        {
                return new List<object[]>
                {                 
                    new object[]
                    {
                        new BundleDto{
                            Id=-9,
                            Name="bundle4",
                            Price=120,
                            AuthorId=-11,
                            ToursId=new List<int>{-13 }
                            
                        },
                        200
                    },
                    new object[]
                    {
                        new BundleDto{
                            Id=-10,
                            Name="bundle5",
                            Price=120,
                            ToursId=new List<int>{-13 }

                        },
                        400
                    }
                };
        }
        


        [Theory]
        [MemberData(nameof(BundleUpdateDtos))]
        public void Update_comment(BundleDto bundle, int expectedResponseCode)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<PaymentsContext>();

            var result = (ObjectResult)controller.Update(bundle).Result;

            // Assert - Response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(expectedResponseCode);

            // Assert - Database


            if (result.StatusCode != 400)
            {
                var storedEntity = dbContext.Bundles.FirstOrDefault(t => t.Id == bundle.Id);
                storedEntity.ShouldNotBeNull();
            }

        }

        public static IEnumerable<object[]> BundleUpdateDtos()
        {
            return new List<object[]>
                {
                    new object[]
                    {
                        new BundleDto{
                            Id=-9,
                            Name="bundle8",
                            Price=120,
                            AuthorId=-11,
                            ToursId=new List<int>{-13 }

                        },
                        200
                    },
                    new object[]
                    {
                        new BundleDto{
                            Id=-10,
                            Name="bundle5",
                            Price=120,
                            AuthorId=-11,
                            ToursId=new List<int>{-13 }

                        },
                        400
                    }
                };
        }

        [Theory]
        [InlineData(-9, 200)]
        [InlineData(-10, 404)]
        public void Delete_comment_fail(int bundleId, int expectedResponseCode)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<PaymentsContext>();

            var result = (ObjectResult)controller.Delete(bundleId);

            // Assert - Response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(expectedResponseCode);

            //Assert - Database

            if (expectedResponseCode != 400)
            {
                var storedEntity = dbContext.Bundles.FirstOrDefault(t => t.Id == bundleId);
                storedEntity.ShouldBeNull();
            }

        }

        private static BundleController CreateController(IServiceScope scope)
        {
            return new BundleController(scope.ServiceProvider.GetRequiredService<IBundleService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }

    }
}
