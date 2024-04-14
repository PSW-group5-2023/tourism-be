using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Infrastructure.Database;
using Explorer.Tours.Core.Domain.Tours;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.Tests.Integration
{
    public class EncounterCommandTests : BaseEncountersIntegrationTest
    {
        public EncounterCommandTests(EncountersTestFactory factory) : base(factory)
        {
        }

        [Fact]
        public void CreatesAsAuthor()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateAuthorController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();
            var newEntity = new EncounterDto
            {
                CreatorId = -11,
                Description = "This encounter is very enjoyable and i really want to write these tests.",
                Name = "Find Nemo",
                Status = 1,
                Latitude = 12.22,
                Longitude = -32.32,
                Type = 2,
                ExperiencePoints = 125,
                Image = null,
                LocationLatitude = null,
                LocationLongitude = null,
                RangeInMeters = null,
                KeyPointId = -17,
                RequiredAttendance = null
            };

            // Act
            var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as EncounterDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.CreatorId.ShouldBe(newEntity.CreatorId);
            result.Description.ShouldBe(newEntity.Description);
            result.Status.ShouldBe(1);
            result.Latitude.ShouldBe(newEntity.Latitude);
            result.Longitude.ShouldBe(newEntity.Longitude);
            result.Type.ShouldBe(newEntity.Type);
            result.ExperiencePoints.ShouldBe(newEntity.ExperiencePoints);
            result.Image.ShouldBe(newEntity.Image);
            result.LocationLatitude.ShouldBe(newEntity.LocationLatitude);
            result.LocationLongitude.ShouldBe(newEntity.LocationLongitude);
            result.RangeInMeters.ShouldBe(newEntity.RangeInMeters);
            result.KeyPointId.ShouldBe(newEntity.KeyPointId);
            result.RequiredAttendance.ShouldBe(newEntity.RequiredAttendance);

            // Assert - Database
            var storedEntity = dbContext.Encounters.FirstOrDefault(i => i.Id == result.Id);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(result.Id);
            storedEntity.CreatorId.ShouldBe(result.CreatorId);
            storedEntity.Description.ShouldBe(result.Description);
            ((int)storedEntity.Status).ShouldBe(result.Status);
            storedEntity.Latitude.ShouldBe(result.Latitude);
            storedEntity.Longitude.ShouldBe(result.Longitude);
            ((int)storedEntity.Type).ShouldBe(result.Type);
            storedEntity.ExperiencePoints.ShouldBe(result.ExperiencePoints);
        }

        [Fact]
        public void CreatesAsAdmin()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateAdministratorController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();
            var newEntity = new EncounterDto
            {
                CreatorId = -1,
                Description = "This encounter is very enjoyable and i really want to write these tests.",
                Name = "Find Nemo",
                Status = 1,
                Latitude = 12.22,
                Longitude = -32.32,
                Type = 2,
                ExperiencePoints = 125,
                Image = null,
                LocationLatitude = null,
                LocationLongitude = null,
                RangeInMeters = null,
                KeyPointId = null,
                RequiredAttendance = null
            };

            // Act
            var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as EncounterDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.CreatorId.ShouldBe(newEntity.CreatorId);
            result.Description.ShouldBe(newEntity.Description);
            result.Status.ShouldBe(1);
            result.Latitude.ShouldBe(newEntity.Latitude);
            result.Longitude.ShouldBe(newEntity.Longitude);
            result.Type.ShouldBe(newEntity.Type);
            result.ExperiencePoints.ShouldBe(newEntity.ExperiencePoints);
            result.Image.ShouldBe(newEntity.Image);
            result.LocationLatitude.ShouldBe(newEntity.LocationLatitude);
            result.LocationLongitude.ShouldBe(newEntity.LocationLongitude);
            result.RangeInMeters.ShouldBe(newEntity.RangeInMeters);
            result.KeyPointId.ShouldBe(newEntity.KeyPointId);
            result.RequiredAttendance.ShouldBe(newEntity.RequiredAttendance);

            // Assert - Database
            var storedEntity = dbContext.Encounters.FirstOrDefault(i => i.Id == result.Id);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(result.Id);
            storedEntity.CreatorId.ShouldBe(result.CreatorId);
            storedEntity.Description.ShouldBe(result.Description);
            ((int)storedEntity.Status).ShouldBe(result.Status);
            storedEntity.Latitude.ShouldBe(result.Latitude);
            storedEntity.Longitude.ShouldBe(result.Longitude);
            ((int)storedEntity.Type).ShouldBe(result.Type);
            storedEntity.ExperiencePoints.ShouldBe(result.ExperiencePoints);
        }


        [Fact]
        public void CreatesAsTourist()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateTouristController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();
            var newEntity = new EncounterDto
            {
                CreatorId = -21,
                Description = "This encounter is very enjoyable and i really want to write these tests.",
                Name = "Find Nemo",
                Status = 1,
                Latitude = 12.22,
                Longitude = -32.32,
                Type = 2,
                ExperiencePoints = 125,
                Image = null,
                LocationLatitude = null,
                LocationLongitude = null,
                RangeInMeters = null,
                KeyPointId = null,
                RequiredAttendance = null
            };

            // Act
            var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as EncounterDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.CreatorId.ShouldBe(-21);
            result.Description.ShouldBe(newEntity.Description);
            result.Status.ShouldBe(0);
            result.Latitude.ShouldBe(newEntity.Latitude);
            result.Longitude.ShouldBe(newEntity.Longitude);
            result.Type.ShouldBe(newEntity.Type);
            result.ExperiencePoints.ShouldBe(newEntity.ExperiencePoints);
            result.Image.ShouldBe(newEntity.Image);
            result.LocationLatitude.ShouldBe(newEntity.LocationLatitude);
            result.LocationLongitude.ShouldBe(newEntity.LocationLongitude);
            result.RangeInMeters.ShouldBe(newEntity.RangeInMeters);
            result.KeyPointId.ShouldBe(newEntity.KeyPointId);
            result.RequiredAttendance.ShouldBe(newEntity.RequiredAttendance);

            // Assert - Database
            var storedEntity = dbContext.Encounters.FirstOrDefault(i => i.Id == result.Id);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(result.Id);
            storedEntity.CreatorId.ShouldBe(result.CreatorId);
            storedEntity.Description.ShouldBe(result.Description);
            ((int)storedEntity.Status).ShouldBe(result.Status);
            storedEntity.Latitude.ShouldBe(result.Latitude);
            storedEntity.Longitude.ShouldBe(result.Longitude);
            ((int)storedEntity.Type).ShouldBe(result.Type);
            storedEntity.ExperiencePoints.ShouldBe(result.ExperiencePoints);
        }

        [Fact]
        public void CreateEncounterExecutionSession()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateTouristController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();
            var newEntity = new EncounterExecutionDto
            {
                TouristId = -21,
                EncounterId = -4,
                ActivationTime = DateTime.UtcNow,
                CompletionTime = null
            };

            // Act
            var result = ((ObjectResult)controller.CreateEncounterExecutionSession(newEntity).Result)?.Value as EncounterExecutionDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.TouristId.ShouldBe(-21);
            result.EncounterId.ShouldBe(newEntity.EncounterId);
            result.ActivationTime.ShouldBe(newEntity.ActivationTime);
            result.CompletionTime.ShouldBe(newEntity.CompletionTime);
            

            // Assert - Database
            var storedEntity = dbContext.EncounterExecutions.FirstOrDefault(i => i.Id == result.Id);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(result.Id);
            storedEntity.TouristId.ShouldBe(result.TouristId);
            storedEntity.EncounterId.ShouldBe(result.EncounterId);
            storedEntity.ActivationTime.ShouldBe(result.ActivationTime);
            storedEntity.CompletionTime.ShouldBe(result.CompletionTime);
        }

        [Fact]
        public void CompleteEncounterExecution()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateTouristController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<EncountersContext>();
            var touristId = -21;
            var encounterId = -3;

            // Act
            var result = ((ObjectResult)controller.Complete(touristId, encounterId).Result)?.Value as EncounterExecutionDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            
            var oldEntity = dbContext.EncounterExecutions.FirstOrDefault(e => e.Id == result.Id);
            
            result.TouristId.ShouldBe(-21);
            result.EncounterId.ShouldBe(oldEntity.EncounterId);
            result.ActivationTime.ShouldBe(oldEntity.ActivationTime);
            result.CompletionTime.ShouldNotBe(null);



            // Assert - Database
            var storedEntity = dbContext.EncounterExecutions.FirstOrDefault(i => i.Id == result.Id);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(result.Id);
            storedEntity.TouristId.ShouldBe(result.TouristId);
            storedEntity.EncounterId.ShouldBe(result.EncounterId);
            storedEntity.ActivationTime.ShouldBe(result.ActivationTime);
            storedEntity.CompletionTime.ShouldBe(result.CompletionTime);
        }

        private static Explorer.API.Controllers.Administrator.EncounterController CreateAdministratorController(IServiceScope scope)
        {
            return new Explorer.API.Controllers.Administrator.EncounterController(scope.ServiceProvider.GetRequiredService<IEncounterService>())
            {
                ControllerContext = BuildEncounterContext("-1")
            };
        }

        private static Explorer.API.Controllers.Author.EncounterController CreateAuthorController(IServiceScope scope)
        {
            return new Explorer.API.Controllers.Author.EncounterController(scope.ServiceProvider.GetRequiredService<IEncounterService>())
            {
                ControllerContext = BuildEncounterContext("-11")
            };
        }

        private static Explorer.API.Controllers.Tourist.EncounterController CreateTouristController(IServiceScope scope)
        {
            return new Explorer.API.Controllers.Tourist.EncounterController(scope.ServiceProvider.GetRequiredService<IEncounterService>(), scope.ServiceProvider.GetRequiredService<IEncounterExecutionService>())
            {
                ControllerContext = BuildEncounterContext("-21")
            };
        }
    }
}
