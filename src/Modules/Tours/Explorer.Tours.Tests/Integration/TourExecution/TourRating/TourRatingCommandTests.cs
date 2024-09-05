using Explorer.API.Controllers.Tourist;
using Explorer.Tours.API.Dtos.Rating;
using Explorer.Tours.API.Public.Rating;
using Explorer.Tours.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Explorer.Tours.Tests.Integration.TourExecution.TourRating
{
    [Collection("Sequential")]
    public class TourRatingCommandTests : BaseToursIntegrationTest
    {
        public TourRatingCommandTests(ToursTestFactory factory) : base(factory) { }

        [Fact]
        public void Creates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope, "1");
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();
            var newEntity = new TourRatingDto
            {
                UserId = 1,
                TourId = 2,
                Mark = 4,
                Comment = "Bilo je odlicno",
                DateOfVisit = DateTime.UtcNow,
                DateOfCommenting = DateTime.UtcNow,
                Images = new List<Uri>()
            };

            // Act
            var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as TourRatingDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.UserId.ShouldBe(newEntity.UserId);
            result.TourId.ShouldBe(newEntity.TourId);
            result.Mark.ShouldBe(newEntity.Mark);
            result.Comment.ShouldBe(newEntity.Comment);
            result.DateOfVisit.ShouldBe(newEntity.DateOfVisit);
            result.DateOfCommenting.ShouldBe(newEntity.DateOfCommenting);
            result.Images.ShouldBeEquivalentTo(newEntity.Images);

            // Assert - Database
            var storedEntity = dbContext.TourRatings.FirstOrDefault(i => i.Comment == newEntity.Comment);
            storedEntity.ShouldNotBeNull();
            storedEntity.UserId.ShouldBe(newEntity.UserId);
            storedEntity.TourId.ShouldBe(newEntity.TourId);
            storedEntity.Mark.ShouldBe(newEntity.Mark);
            storedEntity.Comment.ShouldBe(newEntity.Comment);
            storedEntity.DateOfVisit.ShouldBe(newEntity.DateOfVisit);
            storedEntity.DateOfCommenting.ShouldBe(newEntity.DateOfCommenting);
            storedEntity.Images.ShouldBeEquivalentTo(newEntity.Images);
        }
        [Theory]
        [MemberData(nameof(TourRatingCreationData))]
        public void Creates_fails_invalid_data(TourRatingDto newEntity, int ExpectedStatusCode)
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope, "-21");

            // Act
            var result = (ObjectResult)controller.Create(newEntity).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(ExpectedStatusCode);
        }

        [Fact]
        public void Creates_Mobile()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope, "-21");
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();
            var newEntity = new TourRatingMobileDto
            {
                UserId = 1,
                TourId = 2,
                Mark = 4,
                Comment = "Bilo je odlicno",
                DateOfCommenting = DateTime.UtcNow
            };

            // Act
            var result = ((ObjectResult)controller.CreateMobile(newEntity).Result)?.Value as TourRatingMobileDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.UserId.ShouldBe(newEntity.UserId);
            result.TourId.ShouldBe(newEntity.TourId);
            result.Mark.ShouldBe(newEntity.Mark);
            result.Comment.ShouldBe(newEntity.Comment);
            result.DateOfCommenting.ShouldBe(newEntity.DateOfCommenting);

            // Assert - Database
            var storedEntity = dbContext.TourRatings.FirstOrDefault(i => i.Comment == newEntity.Comment);
            storedEntity.ShouldNotBeNull();
            storedEntity.UserId.ShouldBe(newEntity.UserId);
            storedEntity.TourId.ShouldBe(newEntity.TourId);
            storedEntity.Mark.ShouldBe(newEntity.Mark);
            storedEntity.Comment.ShouldBe(newEntity.Comment);
            storedEntity.DateOfCommenting.ShouldBe(newEntity.DateOfCommenting);
        }
        [Theory]
        [MemberData(nameof(TourRatingCreationDataMobile))]
        public void Creates_fails_invalid_data_Mobile(TourRatingMobileDto newEntity, int ExpectedStatusCode)
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope, "-21");

            // Act
            var result = (ObjectResult)controller.CreateMobile(newEntity).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(ExpectedStatusCode);
        }
        [Fact]
        public void Updates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope, "-21");
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();
            var updatedEntity = new TourRatingDto
            {
                Id = -1,
                UserId = -2,
                TourId = -2,
                Mark = 5,
                Comment = "Bilo je odlicnoo",
                DateOfVisit = DateTime.UtcNow,
                DateOfCommenting = DateTime.UtcNow,
                Images = new List<Uri>()
            };

            // Act
            var result = ((ObjectResult)controller.Update(updatedEntity).Result)?.Value as TourRatingDto;

            // Assert
            // Assert - Response
            result.ShouldNotBeNull();
            result.UserId.ShouldBe(updatedEntity.UserId);
            result.TourId.ShouldBe(updatedEntity.TourId);
            result.Mark.ShouldBe(updatedEntity.Mark);
            result.Comment.ShouldBe(updatedEntity.Comment);
            result.DateOfVisit.ShouldBe(updatedEntity.DateOfVisit);
            result.DateOfCommenting.ShouldBe(updatedEntity.DateOfCommenting);
            result.Images.ShouldBeEquivalentTo(updatedEntity.Images);

            // Assert - Database
            var storedEntity = dbContext.TourRatings.FirstOrDefault(i => i.Comment == updatedEntity.Comment);
            storedEntity.ShouldNotBeNull();
            storedEntity.UserId.ShouldBe(updatedEntity.UserId);
            storedEntity.TourId.ShouldBe(updatedEntity.TourId);
            storedEntity.Mark.ShouldBe(updatedEntity.Mark);
            storedEntity.Comment.ShouldBe(updatedEntity.Comment);
            storedEntity.DateOfVisit.ShouldBe(updatedEntity.DateOfVisit);
            storedEntity.DateOfCommenting.ShouldBe(updatedEntity.DateOfCommenting);
            storedEntity.Images.ShouldBeEquivalentTo(updatedEntity.Images);
        }

        [Theory]
        [MemberData(nameof(TourRatingUpdateData))]
        public void Update_fails(TourRatingDto updatedEntity, int ExpectedStatusCode)
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope, "-21");

            // Act
            var result = (ObjectResult)controller.Update(updatedEntity).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(ExpectedStatusCode);
        }

        public static IEnumerable<object[]> TourRatingCreationDataMobile()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new TourRatingMobileDto
                    {
                        UserId = 1,
                        TourId = 2,
                        Mark = -1,
                        Comment = "Bilo je odlicno",
                        DateOfCommenting = DateTime.UtcNow
                    },
                    400
                },
                new object[]
                {
                    new TourRatingMobileDto
                    {
                        UserId = 1,
                        TourId = 2,
                        Mark = 4,
                        Comment = "",
                        DateOfCommenting = DateTime.UtcNow
                    },
                    400
                },
            };
        }
        public static IEnumerable<object[]> TourRatingCreationData()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new TourRatingDto
                    {
                        UserId = 1,
                        TourId = 2,
                        Mark = -1,
                        Comment = "Bilo je odlicno",
                        DateOfVisit = DateTime.UtcNow,
                        DateOfCommenting = DateTime.UtcNow,
                        Images = new List<Uri>()
                    },
                    400
                },
                new object[]
                {
                    new TourRatingDto
                    {
                        UserId = 1,
                        TourId = 2,
                        Mark = 4,
                        Comment = "",
                        DateOfVisit = DateTime.UtcNow,
                        DateOfCommenting = DateTime.UtcNow,
                        Images = new List<Uri>()
                    },
                    400
                },
            };
        }

        public static IEnumerable<object[]> TourRatingUpdateData()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new TourRatingDto
                    {
                        Id = -1,
                        UserId = 1,
                        TourId = 2,
                        Mark = -1,
                        Comment = "Bilo je odlicno",
                        DateOfVisit = DateTime.UtcNow,
                        DateOfCommenting = DateTime.UtcNow,
                        Images = new List<Uri>()
                    },
                    400
                },
                new object[]
                {
                    new TourRatingDto
                    {
                        Id = -1,
                        UserId = 1,
                        TourId = 2,
                        Mark = 4,
                        Comment = "",
                        DateOfVisit = DateTime.UtcNow,
                        DateOfCommenting = DateTime.UtcNow,
                        Images = new List<Uri>()
                    },
                    400
                },
                new object[]
                {
                    new TourRatingDto
                    {
                        Id = 12345,
                        UserId = 1,
                        TourId = 2,
                        Mark = 4,
                        Comment = "Bilo je odlicno",
                        DateOfVisit = DateTime.UtcNow,
                        DateOfCommenting = DateTime.UtcNow,
                        Images = new List<Uri>()
                    },
                    404
                },
            };
        }

        private static TourRatingController CreateController(IServiceScope scope, string userId)
        {
            return new TourRatingController(scope.ServiceProvider.GetRequiredService<ITourRatingService>(), scope.ServiceProvider.GetRequiredService<ITourRatingMobileService>())
            {
                ControllerContext = BuildContext(userId)
            };
        }
    }
}
