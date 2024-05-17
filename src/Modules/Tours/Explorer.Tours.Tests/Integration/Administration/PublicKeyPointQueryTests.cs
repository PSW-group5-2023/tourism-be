﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.API.Controllers.Administrator.Administration;
using Explorer.API.Controllers.Author;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Tour;
using Explorer.Tours.API.Public.Tour;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Explorer.Tours.Tests.Integration.Administration
{
    [Collection("Sequential")]
    public class TourKeyPointQueryTests : BaseToursIntegrationTest
    {
        public TourKeyPointQueryTests(ToursTestFactory factory) : base(factory)
        {
        }

        [Fact]
        public void RetrievesAll()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            //Act
            var result = ((ObjectResult)controller.GetAll(0, 0).Result)?.Value as PagedResult<CheckpointDto>;

            //Assert
            result.ShouldNotBe(null);
            result.Results.Count.ShouldBe(16);
            result.TotalCount.ShouldBe(16);
        }

        [Fact]
        public void RetrievesAllPublic()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            //Act
            var result = ((ObjectResult)controller.GetAllPublic(0, 0).Result)?.Value as PagedResult<PublicCheckpointDto>;

            //Assert
            result.ShouldNotBe(null);
            result.Results.Count.ShouldBe(4);
            result.TotalCount.ShouldBe(4);
        }

        [Fact]
        public void RetrievesOne()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            //Act
            var result = ((ObjectResult)controller.Get(-1).Result);

            //Assert
            result.ShouldNotBe(null);
            result.StatusCode.ShouldBe(200);
        }

        [Fact]
        public void RetrievesByStatus()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            //Act
            var result = ((ObjectResult)controller.GetByStatus("Pending").Result);

            //Assert
            result.ShouldNotBe(null);
            result.StatusCode.ShouldBe(200);
        }
        [Fact]
        public void RetrievesOneFailedInvalidId()
        {
            //Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            //Act
            var result = ((ObjectResult)controller.Get(-1000).Result);

            //Assert
            result.StatusCode.ShouldBe(404);
        }

        [Fact]
        public void ChangeStatus()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.ChangeStatus(-4, "Approved").Result);

            // Assert
            result.ShouldNotBe(null);
            result.StatusCode.ShouldBe(200);
        }

        private static Explorer.API.Controllers.Administrator.Administration.TourKeyPointController CreateController(IServiceScope scope)
        {
            return new Explorer.API.Controllers.Administrator.Administration.TourKeyPointController(scope.ServiceProvider.GetRequiredService<ICheckpointService>(), scope.ServiceProvider.GetRequiredService<IPublicCheckpointService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}

