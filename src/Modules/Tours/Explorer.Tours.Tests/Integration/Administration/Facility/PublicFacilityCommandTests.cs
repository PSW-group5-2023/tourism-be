using Explorer.API.Controllers.Author;
using Explorer.Tours.API.Dtos.Facility;
using Explorer.Tours.API.Public.Facility;
using Explorer.Tours.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Explorer.Tours.Tests.Integration.Administration.Facility
{
    [Collection("Sequential")]
    public class PublicFacilityCommandTests : BaseToursIntegrationTest
    {
        public PublicFacilityCommandTests(ToursTestFactory factory) : base(factory)
        {

        }

        [Fact]
        public void Creates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();
            var newEntity = new PublicFacilityDto
            {
                Name = "Restoran",
                Description = "Hrana",
                Image = new Uri("https://media-cdn.tripadvisor.com/media/photo-s/1a/08/f9/d7/terasa.jpg"),
                Category = 1,
                Latitude = 14.5243,
                Longitude = 87.4536,
                Status = "Pending",
                CreatorId = -1
            };

            // Act
            var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as PublicFacilityDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.Name.ShouldBe(newEntity.Name);
            result.Description.ShouldBe(newEntity.Description);
            result.Image.ShouldBe(newEntity.Image);
            result.Category.ShouldBe(newEntity.Category);
            result.Latitude.ShouldBe(newEntity.Latitude);
            result.Longitude.ShouldBe(newEntity.Longitude);
            result.Status.ShouldBe(newEntity.Status);

            // Assert - Database
            var storedEntity = dbContext.PublicFacility.FirstOrDefault(i => i.Name == newEntity.Name);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(result.Id);
            storedEntity.Name.ShouldBe(result.Name);
            storedEntity.Description.ShouldBe(result.Description);
            storedEntity.Image.ShouldBe(result.Image);
            ((int)storedEntity.Category).ShouldBe(result.Category);
            storedEntity.Latitude.ShouldBe(result.Latitude);
            storedEntity.Longitude.ShouldBe(result.Longitude);
            storedEntity.Status.ToString().ShouldBe(newEntity.Status);
        }

        [Theory]
        [MemberData(nameof(PublicFacilityCreationData))]
        public void Create_fails_invalid_data(PublicFacilityDto newEntity, int expectedStatusCode)
        {
             // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.Create(newEntity).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(expectedStatusCode);
        }

        public static IEnumerable<object[]> PublicFacilityCreationData()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new PublicFacilityDto
                    {
                        Name = "",
                        Description = "Facility description",
                        Category = 0,
                        Latitude = 0,
                        Longitude = 0,
                        Status = "Pending",
                        CreatorId = -1
                    },
                    400
                },
                new object[]
                {
                    new PublicFacilityDto
                    {
                        Name = "Facility name",
                        Description = "",
                        Category = 0,
                        Latitude = 0,
                        Longitude = 0,
                        Status = "Pending",
                        CreatorId = -1
                    },
                    400
                },
                new object[]
                {
                    new PublicFacilityDto
                    {
                        Name = "Facility name",
                        Description = "Facility description",
                        Category = -1,
                        Latitude = 0,
                        Longitude = 0,
                        Status = "Pending",
                        CreatorId = -1
                    },
                    400
                },
                new object[]
                {
                    new PublicFacilityDto
                    {
                        Name = "Facility name",
                        Description = "Facility description",
                        Category = 0,
                        Latitude = 0,
                        Longitude = 181,
                        Status = "Pending",
                        CreatorId = -1
                    },
                    400
                },
                new object[]
                {
                    new PublicFacilityDto
                    {
                        Name = "Facility name",
                        Description = "Facility description",
                        Category = 0,
                        Latitude = 91,
                        Longitude = 0,
                        Status = "Pending",
                        CreatorId = -1
                    },
                    400
                }
            };
        }

        [Theory]
        [InlineData(-4, "Approved")]
        [InlineData(-4, "Denied")]
        public void Changes_status(int facilityId, string newStatus)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();

            // Act
            var result = ((ObjectResult)controller.ChangeStatus(facilityId, newStatus).Result)?.Value as PublicFacilityDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldBe(facilityId);
            result.Status.ShouldBe(newStatus);

            // Assert - Database
            var storedEntity = dbContext.PublicFacility.Find((long)facilityId);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(result.Id);
            storedEntity.Status.ToString().ShouldBe(newStatus);
        }

        private static FacilityController CreateController(IServiceScope scope)
        {
            return new FacilityController(scope.ServiceProvider.GetRequiredService<IFacilityService>(), scope.ServiceProvider.GetRequiredService<IPublicFacilityService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
