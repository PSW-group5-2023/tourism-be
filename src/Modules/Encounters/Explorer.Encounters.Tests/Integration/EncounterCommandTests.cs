using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Explorer.Encounters.Tests.Integration
{
    [Collection("Sequential")]
    public class EncounterCommandTests : BaseEncountersIntegrationTest
    {
        public EncounterCommandTests(EncountersTestFactory factory) : base(factory) { }

        [Theory]
        [MemberData(nameof(EncounterDtos))]
        public void Creates_for_tourist(EncounterDto encounterDto, int expectedStatusCode)
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateTouristController(scope, "-21");
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();

            // Act
            var result = (ObjectResult)controller.Create(encounterDto).Result;
            var resultObject = result?.Value as EncounterDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(expectedStatusCode);
            if (result.StatusCode != 200) return;

            resultObject.ShouldNotBeNull();
            resultObject.Id.ShouldNotBe(0);
            resultObject.Name.ShouldBe(encounterDto.Name);
            resultObject.Description.ShouldBe(encounterDto.Description);
            resultObject.Longitude.ShouldBe(encounterDto.Longitude);
            resultObject.Latitude.ShouldBe(encounterDto.Latitude);
            resultObject.Status.ShouldBe(0);
            resultObject.CreatorId.ShouldBe(-21);
            resultObject.KeyPointId.ShouldBeNull();

            // Assert - Database
            var storedEntity = dbContext.Encounters.FirstOrDefault(i => i.Id == resultObject.Id);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(resultObject.Id);
        }

        public static IEnumerable<object[]> EncounterDtos()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new EncounterDto()
                    {
                        Description = "Na očaravajućem ostrvu Santorini, turista može se suočiti s izazovom istraživanja skrivenih staza i slikovitih sokaka, otkrivajući autentične grčke trenutke izvan uobičajenih turističkih ruta.",
                        Name = "asdasdsadas",
                        Type = 0,
                        Longitude = 50,
                        Latitude = 50,
                        ExperiencePoints = 10,
                        RequiredAttendance = 2,
                        RangeInMeters = 50,
                        Status = 2,
                        CreatorId = 1,
                    },
                    200
                },
                new object[]
                {
                    new EncounterDto()
                    {
                        Description = "Na očaravajućem ostrvu Santorini, turista može se suočiti s izazovom istraživanja skrivenih staza i slikovitih sokaka, otkrivajući autentične grčke trenutke izvan uobičajenih turističkih ruta.",
                        Name = "asdasdsadas",
                        Type = 1,
                        Longitude = 50,
                        Latitude = 50,
                        ExperiencePoints = 10,
                        Image = new Uri("https://upload.wikimedia.org/wikipedia/commons/c/c1/Serbia-0268_-_Name_of_Mary_Parish_Church_(7344449164).jpg"),
                        LocationLatitude = 50,
                        LocationLongitude = 50,
                        Status = 2,
                        CreatorId = 1,
                    },
                    200
                },
                new object[]
                {
                    new EncounterDto()
                    {
                        Description = "Na očaravajućem ostrvu Santorini, turista može se suočiti s izazovom istraživanja skrivenih staza i slikovitih sokaka, otkrivajući autentične grčke trenutke izvan uobičajenih turističkih ruta.",
                        Name = "asdasdsadas",
                        Type = 2,
                        Longitude = 50,
                        Latitude = 50,
                        ExperiencePoints = 10,
                        Status = 2,
                        CreatorId = 1,
                    },
                    200
                },
                new object[]
                {
                    new EncounterDto()
                    {
                        Description = "",
                        Name = "asdasdsadas",
                        Type = 2,
                        Longitude = 50,
                        Latitude = 50,
                        ExperiencePoints = 10,
                        RequiredAttendance = 2,
                        RangeInMeters = 50,
                        Status = 2,
                        CreatorId = 1,
                    },
                    400
                },
                new object[]
                {
                    new EncounterDto()
                    {
                        Description = "Na očaravajućem ostrvu Santorini, turista može se suočiti s izazovom istraživanja skrivenih staza i slikovitih sokaka, otkrivajući autentične grčke trenutke izvan uobičajenih turističkih ruta.",
                        Name = "",
                        Type = 2,
                        Longitude = 50,
                        Latitude = 50,
                        ExperiencePoints = 10,
                        RequiredAttendance = 2,
                        RangeInMeters = 50,
                        Status = 2,
                        CreatorId = 1,
                    },
                    400
                },
                new object[]
                {
                    new EncounterDto()
                    {
                        Description = "Na očaravajućem ostrvu Santorini, turista može se suočiti s izazovom istraživanja skrivenih staza i slikovitih sokaka, otkrivajući autentične grčke trenutke izvan uobičajenih turističkih ruta.",
                        Name = "asdasdsadas",
                        Type = 2,
                        Longitude = 50,
                        Latitude = 100,
                        ExperiencePoints = 10,
                        RequiredAttendance = 2,
                        RangeInMeters = 50,
                        Status = 2,
                        CreatorId = 1,
                    },
                    400
                },
                new object[]
                {
                    new EncounterDto()
                    {
                        Description = "Na očaravajućem ostrvu Santorini, turista može se suočiti s izazovom istraživanja skrivenih staza i slikovitih sokaka, otkrivajući autentične grčke trenutke izvan uobičajenih turističkih ruta.",
                        Name = "asdasdsadas",
                        Type = 2,
                        Longitude = 190,
                        Latitude = 50,
                        ExperiencePoints = 10,
                        RequiredAttendance = 2,
                        RangeInMeters = 50,
                        Status = 2,
                        CreatorId = 1,
                    },
                    400
                },
                new object[]
                {
                    new EncounterDto()
                    {
                        Description = "Na očaravajućem ostrvu Santorini, turista može se suočiti s izazovom istraživanja skrivenih staza i slikovitih sokaka, otkrivajući autentične grčke trenutke izvan uobičajenih turističkih ruta.",
                        Name = "asdasdsadas",
                        Type = 2,
                        Longitude = 50,
                        Latitude = 50,
                        ExperiencePoints = 0,
                        RequiredAttendance = 2,
                        RangeInMeters = 50,
                        Status = 2,
                        CreatorId = 1,
                    },
                    400
                },
                new object[]
                {
                    new EncounterDto()
                    {
                        Description = "Na očaravajućem ostrvu Santorini, turista može se suočiti s izazovom istraživanja skrivenih staza i slikovitih sokaka, otkrivajući autentične grčke trenutke izvan uobičajenih turističkih ruta.",
                        Name = "asdasdsadas",
                        Type = 0,
                        Longitude = 50,
                        Latitude = 50,
                        ExperiencePoints = 10,
                        RequiredAttendance = 2,
                        RangeInMeters = 0,
                        Status = 2,
                        CreatorId = 1,
                    },
                    400
                },
                new object[]
                {
                    new EncounterDto()
                    {
                        Description = "Na očaravajućem ostrvu Santorini, turista može se suočiti s izazovom istraživanja skrivenih staza i slikovitih sokaka, otkrivajući autentične grčke trenutke izvan uobičajenih turističkih ruta.",
                        Name = "asdasdsadas",
                        Type = 0,
                        Longitude = 50,
                        Latitude = 50,
                        ExperiencePoints = 10,
                        RequiredAttendance = 0,
                        RangeInMeters = 50,
                        Status = 2,
                        CreatorId = 1,
                    },
                    400
                },
                new object[]
                {
                    new EncounterDto()
                    {
                        Description = "Na očaravajućem ostrvu Santorini, turista može se suočiti s izazovom istraživanja skrivenih staza i slikovitih sokaka, otkrivajući autentične grčke trenutke izvan uobičajenih turističkih ruta.",
                        Name = "asdasdsadas",
                        Type = 1,
                        Longitude = 50,
                        Latitude = 50,
                        ExperiencePoints = 10,
                        Image = new Uri("https://upload.wikimedia.org/wikipedia/commons/c/c1/Serbia-0268_-_Name_of_Mary_Parish_Church_(7344449164).jpg"),
                        LocationLatitude = 100,
                        LocationLongitude = 50,
                        Status = 2,
                        CreatorId = 1,
                    },
                    400
                },
                new object[]
                {
                    new EncounterDto()
                    {
                        Description = "Na očaravajućem ostrvu Santorini, turista može se suočiti s izazovom istraživanja skrivenih staza i slikovitih sokaka, otkrivajući autentične grčke trenutke izvan uobičajenih turističkih ruta.",
                        Name = "asdasdsadas",
                        Type = 1,
                        Longitude = 50,
                        Latitude = 50,
                        ExperiencePoints = 10,
                        Image = new Uri("https://upload.wikimedia.org/wikipedia/commons/c/c1/Serbia-0268_-_Name_of_Mary_Parish_Church_(7344449164).jpg"),
                        LocationLatitude = 50,
                        LocationLongitude = 190,
                        Status = 2,
                        CreatorId = 1,
                    },
                    400
                },
            };
        }

        [Fact]
        public void Create_fails_low_level_for_tourist()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateTouristController(scope, "-22");
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();
            var newEntity = new EncounterDto
            {
                Description = "Na očaravajućem ostrvu Santorini, turista može se suočiti s izazovom istraživanja skrivenih staza i slikovitih sokaka, otkrivajući autentične grčke trenutke izvan uobičajenih turističkih ruta.",
                Name = "asdasdsadas",
                Type = 0,
                Longitude = 50,
                Latitude = 50,
                ExperiencePoints = 10,
                RequiredAttendance = 2,
                RangeInMeters = 50,
                Status = 2,
                CreatorId = 1,
            };

            // Act
            var result = ((ObjectResult)controller.Create(newEntity).Result);

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(400);
        }

        [Fact]
        public void Create_fails_not_public_for_tourist()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateTouristController(scope, "-21");
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();
            var newEntity = new EncounterDto
            {
                Description = "Na očaravajućem ostrvu Santorini, turista može se suočiti s izazovom istraživanja skrivenih staza i slikovitih sokaka, otkrivajući autentične grčke trenutke izvan uobičajenih turističkih ruta.",
                Name = "asdasdsadas",
                Type = 0,
                Longitude = 50,
                Latitude = 50,
                ExperiencePoints = 10,
                RequiredAttendance = 2,
                RangeInMeters = 50,
                Status = 2,
                CreatorId = 1,
                KeyPointId = 2,
            };

            // Act
            var result = ((ObjectResult)controller.Create(newEntity).Result);

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(400);
        }

        [Fact]
        public void Updates_for_tourist()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateTouristController(scope, "-21");
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();
            var updatedEntity = new EncounterDto
            {
                Id = -9,
                Name = "Update",
                Description = "update test",
                ExperiencePoints = 10,
                RangeInMeters = 66,
                RequiredAttendance = 22
            };

            // Act
            var result = ((ObjectResult)controller.Update(updatedEntity).Result)?.Value as EncounterDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldBe(-9);
            result.Name.ShouldBe(updatedEntity.Name);
            result.Description.ShouldBe(updatedEntity.Description);
            result.Status.ShouldBe(0);

            // Assert - Database
            var storedEntity = dbContext.Encounters.FirstOrDefault(i => i.Name == "Update");
            storedEntity.ShouldNotBeNull();
            storedEntity.Description.ShouldBe(updatedEntity.Description);
            var oldEntity = dbContext.Encounters.FirstOrDefault(i => i.Name == "Demo izazov");
            oldEntity.ShouldBeNull();
        }

        [Fact]
        public void Update_fails_not_owner_for_tourist()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateTouristController(scope, "-21");
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();
            var updatedEntity = new EncounterDto
            {
                Id = -1,
                Name = "Update",
                Description = "update test"
            };

            // Act
            var result = ((ObjectResult)controller.Update(updatedEntity).Result);

            // Assert - Response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(400);
        }

        [Fact]
        public void Update_fails_added_keypoint_for_tourist()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateTouristController(scope, "-21");
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();
            var updatedEntity = new EncounterDto
            {
                Id = -9,
                Name = "Update",
                Description = "update test",
                KeyPointId = 1,
            };

            // Act
            var result = (ObjectResult)controller.Update(updatedEntity).Result;

            // Assert - Response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(400);
        }

        [Fact]
        public void Deletes()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateTouristController(scope, "-21");
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();

            // Act
            var result = (OkObjectResult)controller.Delete(-6);

            // Assert - Response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(200);

            // Assert - Database
            var storedCourse = dbContext.Encounters.FirstOrDefault(i => i.Id == -6);
            storedCourse.ShouldBeNull();
        }

        [Fact]
        public void Delete_fails_not_owner()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateTouristController(scope, "-21");
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();

            // Act
            var result = (ObjectResult)controller.Delete(-1);

            // Assert - Response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(400);
        }

        [Fact]
        public void Starts_encounter()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateTouristController(scope, "-21");
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();

            // Act
            var result = ((ObjectResult)controller.StartEncounter(-4).Result)?.Value as EncounterExecutionDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.CompletionTime.ShouldBeNull();
            result.InRange.ShouldBeFalse();
            result.ActivationTime.ShouldBe(DateTime.UtcNow, TimeSpan.FromSeconds(5));

            // Assert - Database
            var storedEntity = dbContext.EncounterExecutions.FirstOrDefault(i => i.EncounterId == -4 && i.TouristId == -21);
            storedEntity.ShouldNotBeNull();
            storedEntity.ActivationTime.ShouldBe(DateTime.UtcNow, TimeSpan.FromSeconds(5));
            storedEntity.CompletionTime.ShouldBeNull();
            storedEntity.InRange.ShouldBeFalse();
        }

        [Fact]
        public void Start_fails_already_started()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateTouristController(scope, "-21");
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();

            // Act
            var result = (ObjectResult)controller.StartEncounter(-1).Result;

            // Assert - Response
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(500);
        }

        [Fact]
        public void Completes_encounter()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateTouristController(scope, "-21");
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();

            // Act
            var result = ((ObjectResult)controller.Complete(-3).Result)?.Value as EncounterExecutionDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.CompletionTime.ShouldNotBeNull();

            // Assert - Database
            var storedEntity = dbContext.EncounterExecutions.FirstOrDefault(e => e.EncounterId == -3 && e.TouristId == -21);
            storedEntity.ShouldNotBeNull();
            storedEntity.CompletionTime.ShouldNotBeNull();
        }

        [Fact]
        public void Creates_for_author()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateAuthorController(scope, "-11");
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();
            var newEntity = new EncounterDto()
            {
                Description = "Test",
                Name = "Test",
                Status = 0,
                Latitude = 50,
                Longitude = 50,
                Type = 2,
                ExperiencePoints = 10,
                KeyPointId = -17,
            };

            // Act
            var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as EncounterDto;

            // Assert - Response

            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.Name.ShouldBe(newEntity.Name);
            result.Description.ShouldBe(newEntity.Description);
            result.Longitude.ShouldBe(12.3);
            result.Latitude.ShouldBe(24.22);
            result.Status.ShouldBe(1);
            result.CreatorId.ShouldBe(-11);
            result.KeyPointId.ShouldBe(-17);

            // Assert - Database
            var storedEntity = dbContext.Encounters.FirstOrDefault(i => i.Id == result.Id);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(result.Id);
        }

        [Fact]
        public void Create_fails_not_keypoint_owner_for_author()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateAuthorController(scope, "-12");
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();
            var newEntity = new EncounterDto()
            {
                Description = "Test",
                Name = "Test",
                Status = 0,
                Latitude = 50,
                Longitude = 50,
                Type = 2,
                ExperiencePoints = 10,
                KeyPointId = -17,
            };

            // Act
            var result = (ObjectResult)controller.Create(newEntity).Result;

            // Assert - Response

            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(400);
        }

        [Fact]
        public void Create_fails_no_keypoint_set_for_author()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateAuthorController(scope, "-11");
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();
            var newEntity = new EncounterDto()
            {
                Description = "Test",
                Name = "Test",
                Status = 0,
                Latitude = 50,
                Longitude = 50,
                Type = 2,
                ExperiencePoints = 10,
            };

            // Act
            var result = (ObjectResult)controller.Create(newEntity).Result;

            // Assert - Response

            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(400);
        }

        [Fact]
        public void Updates_for_author()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateAuthorController(scope, "-11");
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();
            var updatedEntity = new EncounterDto
            {
                Id = -7,
                Name = "Update",
                Description = "update test",
                ExperiencePoints = 10,
                KeyPointId = -17,
                Status = 1,
                Type = 2,
            };

            // Act
            var result = ((ObjectResult)controller.Update(updatedEntity).Result)?.Value as EncounterDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldBe(-7);
            result.Name.ShouldBe(updatedEntity.Name);
            result.Description.ShouldBe(updatedEntity.Description);
            result.Status.ShouldBe(updatedEntity.Status);
            result.Longitude.ShouldBe(12.3);
            result.Latitude.ShouldBe(24.22);

            // Assert - Database
            var storedEntity = dbContext.Encounters.FirstOrDefault(i => i.Name == "Update");
            storedEntity.ShouldNotBeNull();
            storedEntity.Description.ShouldBe(updatedEntity.Description);
            var oldEntity = dbContext.Encounters.FirstOrDefault(i => i.Name == "Challenge for acrobat");
            oldEntity.ShouldBeNull();
        }

        [Fact]
        public void Creates_for_administrator()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateAdministratorController(scope, "-1");
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();
            var newEntity = new EncounterDto()
            {
                Description = "Test",
                Name = "Test",
                Status = 0,
                Latitude = 50,
                Longitude = 50,
                Type = 2,
                ExperiencePoints = 10,
            };

            // Act
            var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as EncounterDto;

            // Assert - Response

            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.Name.ShouldBe(newEntity.Name);
            result.Description.ShouldBe(newEntity.Description);
            result.Longitude.ShouldBe(50);
            result.Latitude.ShouldBe(50);
            result.Status.ShouldBe(1);
            result.CreatorId.ShouldBe(-1);
            result.KeyPointId.ShouldBeNull();

            // Assert - Database
            var storedEntity = dbContext.Encounters.FirstOrDefault(i => i.Id == result.Id);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(result.Id);
        }

        [Fact]
        public void Create_fails_keypoint_set_for_administrator()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateAdministratorController(scope, "-1");
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();
            var newEntity = new EncounterDto()
            {
                Description = "Test",
                Name = "Test",
                Status = 0,
                Latitude = 50,
                Longitude = 50,
                Type = 2,
                ExperiencePoints = 10,
                KeyPointId = -17,
            };

            // Act
            var result = (ObjectResult)controller.Create(newEntity).Result;

            // Assert - Response

            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(400);
        }

        [Fact]
        public void Updates_for_administrator()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateAdministratorController(scope, "-1");
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();
            var updatedEntity = new EncounterDto
            {
                Id = -7,
                Name = "Update",
                Description = "update test",
                ExperiencePoints = 10,
                Status = 1,
                Type = 2,
                Latitude = 66,
                Longitude = 66,
                CreatorId = -11,
            };

            // Act
            var result = ((ObjectResult)controller.Update(updatedEntity).Result)?.Value as EncounterDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldBe(-7);
            result.Name.ShouldBe(updatedEntity.Name);
            result.Description.ShouldBe(updatedEntity.Description);
            result.Status.ShouldBe(updatedEntity.Status);
            result.Longitude.ShouldBe(updatedEntity.Longitude);
            result.Latitude.ShouldBe(updatedEntity.Latitude);

            // Assert - Database
            var storedEntity = dbContext.Encounters.FirstOrDefault(i => i.Name == "Update");
            storedEntity.ShouldNotBeNull();
            storedEntity.Description.ShouldBe(updatedEntity.Description);
            var oldEntity = dbContext.Encounters.FirstOrDefault(i => i.Name == "Challenge for acrobat");
            oldEntity.ShouldBeNull();
        }

        [Fact]
        public void Activates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateAdministratorController(scope, "-1");
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();

            // Act
            var result = ((ObjectResult)controller.Activate(-3).Result)?.Value as EncounterDto;

            // Arrange - Reponse
            result.ShouldNotBeNull();
            result.Status.ShouldBe(1);

            // Arrange - Database
            var storedEntity = dbContext.Encounters.FirstOrDefault(e => e.Id == -3);
            storedEntity.ShouldNotBeNull();
            ((int)storedEntity.Status).ShouldBe(1);
        }

        [Fact]
        public void Archives()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateAdministratorController(scope, "-1");
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();

            // Act
            var result = ((ObjectResult)controller.Archive(-4).Result)?.Value as EncounterDto;

            // Arrange - Reponse
            result.ShouldNotBeNull();
            result.Status.ShouldBe(2);

            // Arrange - Database
            var storedEntity = dbContext.Encounters.FirstOrDefault(e => e.Id == -4);
            storedEntity.ShouldNotBeNull();
            ((int)storedEntity.Status).ShouldBe(2);
        }

        private static Explorer.API.Controllers.Administrator.EncounterController CreateAdministratorController(IServiceScope scope, string userId)
        {
            return new Explorer.API.Controllers.Administrator.EncounterController(scope.ServiceProvider.GetRequiredService<IEncounterService>())
            {
                ControllerContext = BuildEncounterContext(userId)
            };
        }

        private static Explorer.API.Controllers.Author.EncounterController CreateAuthorController(IServiceScope scope, string userId)
        {
            return new Explorer.API.Controllers.Author.EncounterController(scope.ServiceProvider.GetRequiredService<IEncounterService>())
            {
                ControllerContext = BuildEncounterContext(userId)
            };
        }

        private static Explorer.API.Controllers.Tourist.EncounterController CreateTouristController(IServiceScope scope, string userId)
        {
            return new Explorer.API.Controllers.Tourist.EncounterController(scope.ServiceProvider.GetRequiredService<IEncounterService>())
            {
                ControllerContext = BuildEncounterContext(userId)
            };
        }
    }
}
