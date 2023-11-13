﻿using Explorer.API.Controllers.Execution;
using Explorer.Blog.API.Dtos;
using Explorer.Blog.API.Public;
using Explorer.Blog.Infrastructure.Database;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Execution;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.Sessions;
using Explorer.Tours.Infrastructure.Database;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Tests.Integration.TourExecution
{
    [Collection("Sequential")]
    public class SessionCommandTests : BaseToursIntegrationTest
    {
        public SessionCommandTests(ToursTestFactory factory) : base(factory)
        {
        }

        [Theory]
        [MemberData(nameof(SessionDto))]
        public void Update_session(SessionDto session, int expectedResponseCode)
        {
            using var scope = Factory.Services.CreateScope();

            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();

            var result = (ObjectResult)controller.Update(session).Result;

            result.ShouldNotBeNull();

            result.StatusCode.ShouldBe(expectedResponseCode);

            // Assert - Database
            var storedEntity = dbContext.Sessions.FirstOrDefault(t => t.Id == session.Id);
            storedEntity.ShouldNotBeNull();
        }

        [Theory]
        [MemberData(nameof(SessionDto1))]
        public void Create_session(SessionDto session, int expectedResponseCode)
        {
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();

            var result = (ObjectResult)controller.Create(session).Result;

            result.StatusCode.ShouldBe(expectedResponseCode);

            // Assert - Database
            var storedEntity = dbContext.Sessions.FirstOrDefault(t => t.Id == session.Id);
            storedEntity.ShouldNotBeNull();
        }
        public static IEnumerable<object[]> SessionDto()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new SessionDto
                    {
                        Id = -1,
                        TourId = -1,
                        TouristId = -21,
                        Location = new PositionSimulatorDto(),
                        SessionStatus = 1,
                        DistanceCrossedPercent = 10,
                        LastActivity = DateTime.UtcNow,
                        CompletedKeyPoints = new List<CompletedKeyPointDto>()
                    },
                    200
                }
            };
        }
        public static IEnumerable<object[]> SessionDto1()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new SessionDto
                    {
                        Id = -11,
                        TourId = -2,
                        TouristId = -22,
                        Location = new PositionSimulatorDto(),
                        SessionStatus = 1,
                        DistanceCrossedPercent = 10,
                        LastActivity = DateTime.UtcNow,
                        CompletedKeyPoints = new List<CompletedKeyPointDto>()
                    },
                    200
                }
            };
        }


        private static SessionController CreateController(IServiceScope scope)
        {
            return new SessionController(scope.ServiceProvider.GetRequiredService<ISessionService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
