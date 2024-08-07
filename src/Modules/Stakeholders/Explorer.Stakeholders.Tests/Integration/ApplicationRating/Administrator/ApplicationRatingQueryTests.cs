﻿using Explorer.API.Controllers.Administrator;
using Explorer.API.Controllers.Administrator.Administration;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Tours.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Tests.Integration.ApplicationRating.Administrator
{
    [Collection("Sequential")]
    public class ApplicationRatingQueryTests : BaseStakeholdersIntegrationTest
    {
        public ApplicationRatingQueryTests(StakeholdersTestFactory factory) : base(factory) { }

        [Fact]
        public void Retrieves_all()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);

            // Act
            var result = ((ObjectResult)controller.GetAll(0, 0).Result)?.Value as PagedResult<ApplicationRatingDto>;

            // Assert
            result.ShouldNotBeNull();
            result.Results.Count.ShouldBe(6);
            result.TotalCount.ShouldBe(6);
        }

        private static ApplicationRatingController CreateController(IServiceScope scope)
        {
            return new ApplicationRatingController(scope.ServiceProvider.GetRequiredService<IApplicationRatingService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
