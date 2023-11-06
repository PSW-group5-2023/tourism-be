﻿using Explorer.API.Controllers.Administrator.Administration;
using Explorer.API.Controllers.Author;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Tests.Integration.TourAuthoring
{
    [Collection("Sequential")]
    public class TourCommandTest : BaseToursIntegrationTest
    {

        public TourCommandTest(ToursTestFactory factory) : base(factory) { }

        [Fact]
        public void Creates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();
            var newEntity = new TourDto
            {
                Name = "Tura 5",
                Description = "Jako lepa tura idemo.",
                Difficulty = "BEGINNER",
                Tags = "#freedesingerica",
                Status = 1,
                Price = 0,
                AuthorId = -1,
                //Equipment = [],
                ArchivedDate = null
            };

            // Act
            var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as TourDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.Name.ShouldBe(newEntity.Name);
            result.Description.ShouldBe(newEntity.Description);
            result.Difficulty.ShouldBe(newEntity.Difficulty);
            result.Tags.ShouldBe(newEntity.Tags);
            result.Status.ShouldBe(newEntity.Status);
            result.Price.ShouldBe(newEntity.Price);
            result.AuthorId.ShouldBe(newEntity.AuthorId);
            //result.Equipment.ShouldBe(newEntity.Equipment);
            result.ArchivedDate.ShouldBe(newEntity.ArchivedDate);


            // Assert - Database
            var storedEntity = dbContext.Tour.FirstOrDefault(i => i.Name == newEntity.Name);
            storedEntity.ShouldNotBeNull();
            storedEntity.Id.ShouldBe(result.Id);
            storedEntity.Name.ShouldBe(result.Name);
            storedEntity.Description.ShouldBe(result.Description);
            storedEntity.Difficulty.ShouldBe(result.Difficulty);
            storedEntity.Tags.ShouldBe(result.Tags);
            ((int)storedEntity.Status).ShouldBe(result.Status);
            storedEntity.Price.ShouldBe(result.Price);
            storedEntity.AuthorId.ShouldBe(result.AuthorId);
            //storedEntity.Equipment.ShouldBe(result.Equipment);
            storedEntity.ArchivedDate.ShouldBe(result.ArchivedDate);
        }

        [Fact]
        public void Updates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();
            var updatedEntity = new TourDto
            {
                Id = -1,
                Name = "Tura 1",
                Description = "Ova tura je lepa",
                Difficulty = "BEGINNER",
                Tags = "#tag1",
                Status = 2,
                Price = 0,
                AuthorId = -1,
                //Equipment = [],
                ArchivedDate = null
            };

            // Act
            var result = ((ObjectResult)controller.Update(updatedEntity).Result)?.Value as TourDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldBe(-1);
            result.Name.ShouldBe(updatedEntity.Name);
            result.Description.ShouldBe(updatedEntity.Description);
            result.Difficulty.ShouldBe(updatedEntity.Difficulty);
            result.Tags.ShouldBe(updatedEntity.Tags);
            result.Status.ShouldBe(updatedEntity.Status);
            result.Price.ShouldBe(updatedEntity.Price);
            result.AuthorId.ShouldBe(updatedEntity.AuthorId);
            //result.Equipment.ShouldBe(updatedEntity.Equipment);
            result.ArchivedDate.ShouldBe(updatedEntity.ArchivedDate);

            // Assert - Database
            var storedEntity = dbContext.Tour.FirstOrDefault(i => i.Status == TourStatus.Archived && i.Name == "Tura 1");
            storedEntity.ShouldNotBeNull();
            ((int)storedEntity.Status).ShouldBe(updatedEntity.Status);
            var oldEntity = dbContext.Tour.FirstOrDefault(i => i.Status == TourStatus.Published && i.Name == "Tura 1");
            oldEntity.ShouldBeNull();
        }

        private static TourController CreateController(IServiceScope scope)
        {
            return new TourController(scope.ServiceProvider.GetRequiredService<ITourService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
