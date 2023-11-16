using Explorer.API.Controllers.Administrator;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Tests.Integration.TourProblem;

[Collection("Sequential")]
public class TourProblemQueryTests : BaseToursIntegrationTest
{
    public TourProblemQueryTests(ToursTestFactory factory) : base(factory) { }

    [Fact]
    public void Retrieves_all()
    {
        // Arrange
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        // Act
        var result = ((ObjectResult)controller.GetAll(0, 0).Result)?.Value as PagedResult<TourProblemDto>;

        // Assert
        result.ShouldNotBeNull();
        result.Results.Count.ShouldBe(3);
        result.TotalCount.ShouldBe(3);
    }

    [Fact]
    public void GiveDeadline()
    {
        // Arrange
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);
        List<TourProblemMessageDto> messages = JsonConvert.DeserializeObject<List<TourProblemMessageDto>>(@"[
                {
                    ""UserId"": 1,
                    ""CreationTime"": ""2023-11-07T12:34:56.789Z"",
                    ""Description"": ""Lorem ipsum dolor sit amet, consectetur adipiscing elit."",
                    ""IsRead"": false
                }
            ]");

        TourProblemDto newTourProblem = new TourProblemDto()
        {
            Id = 3,
            TouristId = 6,
            TourId = 2,
            Category = API.Dtos.TourProblemCategory.BOOKING,
            Priority = API.Dtos.TourProblemPriority.LOW,
            Description = "Ne moze se rezervisati ova tura",
            Time = DateTime.Parse("2023-11-05T12:34:56.789Z"),
            IsSolved = false,
            Messages = messages,
            Deadline = DateTime.Parse("2023-11-28T12:34:56.789Z")
        };
        // Act
        var result = ((ObjectResult)controller.GiveDeadline(newTourProblem).Result)?.Value as PagedResult<TourProblemDto>;

        // Assert
        result.ShouldNotBeNull();
        result.Results[0].ShouldNotBeNull();
    }
    private static TourProblemController CreateController(IServiceScope scope)
    {
        return new TourProblemController(scope.ServiceProvider.GetRequiredService<ITourProblemService>())
        {
            ControllerContext = BuildContext("-1")
        };
    }
}
