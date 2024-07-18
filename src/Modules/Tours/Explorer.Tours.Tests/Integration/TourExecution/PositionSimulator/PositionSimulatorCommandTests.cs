using Explorer.API.Controllers.Execution;
using Explorer.Tours.API.Dtos.Execution;
using Explorer.Tours.API.Public.Execution;
using Explorer.Tours.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Explorer.Tours.Tests.Integration.TourExecution.PositionSimulator
{
    [Collection("Sequential")]
    public class PositionSimulatorCommandTests : BaseToursIntegrationTest
    {
        public PositionSimulatorCommandTests(ToursTestFactory factory) : base(factory)
        {
        }

        [Fact]
        public void Creates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();
            var newEntity = new PositionSimulatorDto
            {
                Id = -24,
                Latitude = 44.4,
                Longitude = 44.4,
                TouristId = -24,
            };

            // Act
            var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as PositionSimulatorDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.Longitude.ShouldBe(newEntity.Longitude);
            result.Latitude.ShouldBe(newEntity.Latitude);
            result.TouristId.ShouldBe(newEntity.TouristId);

            // Assert - Database
            var storedEntity = dbContext.PositionSimulators.FirstOrDefault(i => i.Longitude == newEntity.Longitude);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(result.Id);
            storedEntity.Latitude.ShouldBe(newEntity.Latitude);
            storedEntity.Longitude.ShouldBe(newEntity.Longitude);
            storedEntity.TouristId.ShouldBe(newEntity.TouristId);
        }

        [Theory]
        [MemberData(nameof(PositionSimulatorCreationData))]
        public void Create_fails_invalid_data(PositionSimulatorDto newEntity, int expectedStatusCode)
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = (ObjectResult)controller.Create(newEntity).Result;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(expectedStatusCode);
        }

        public static IEnumerable<object[]> PositionSimulatorCreationData()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new PositionSimulatorDto
                    {
                        Latitude = - 91,
                        Longitude = 0
                    },
                    400
                },
                new object[]
                {
                    new PositionSimulatorDto
                    {
                        Latitude = 0,
                        Longitude = -191
                    },
                    400
                }
            };
        }

        [Fact]
        public void Update()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();
            var updatedEntity = new PositionSimulatorDto
            {
                Id = -21,
                Longitude = 10,
                Latitude = 10,
                TouristId = -21
            };

            //Act
            var result = ((ObjectResult)controller.Update(updatedEntity).Result)?.Value as PositionSimulatorDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldBe(updatedEntity.Id);
            result.Latitude.ShouldBe(updatedEntity.Latitude);
            result.Longitude.ShouldBe(updatedEntity.Longitude);
            result.TouristId.ShouldBe(updatedEntity.TouristId);

            // Assert - Database
            var storedEntity = dbContext.PositionSimulators.FirstOrDefault(i => i.Id == -21);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(updatedEntity.Id);
            storedEntity.Latitude.ShouldBe(updatedEntity.Latitude);
            storedEntity.Longitude.ShouldBe(updatedEntity.Longitude);
            storedEntity.TouristId.ShouldBe(updatedEntity.TouristId);
        }

        [Theory]
        [MemberData(nameof(PositionSimulatorUpdateData))]
        public void Update_fails(PositionSimulatorDto updatedEntity, int expectedStatusCode)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            //Act
            var result = (ObjectResult)controller.Update(updatedEntity).Result;

            //Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(expectedStatusCode);
        }

        public static IEnumerable<object[]> PositionSimulatorUpdateData()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new PositionSimulatorDto
                    {
                        Id = -21,
                        Latitude = - 91,
                        Longitude = 0
                    },
                    400
                },
                new object[]
                {
                    new PositionSimulatorDto
                    {
                        Id = -21,
                        Latitude = 0,
                        Longitude = -191
                    },
                    400
                },
                new object[]
                {
                    new PositionSimulatorDto
                    {
                        Id = 123,
                        Latitude = 0,
                        Longitude = 0
                    },
                    404
                }
            };
        }

        private static PositionSimulatorController CreateController(IServiceScope scope)
        {
            return new PositionSimulatorController(scope.ServiceProvider.GetRequiredService<IPositionSimulatorService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
