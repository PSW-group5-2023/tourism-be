using Explorer.API.Controllers.Tourist;
using Explorer.Tours.API.Public.Problem;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Explorer.Tours.Tests.Integration.Administration.TourProblem;

[Collection("Sequential")]
public class TourProblemMessagingTests : BaseToursIntegrationTest
{
    public TourProblemMessagingTests(ToursTestFactory factory) : base(factory) { }

    [Fact]
    public void Retrieves_by_tourist_id()
    {
        // Arrange
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope);

        // Act
        var result = (ObjectResult)controller.GetByTouristId(-6).Result;

        // Assert
        result.ShouldNotBe(null);
        result.StatusCode.ShouldBe(200);
    }
    private static TourProblemController CreateController(IServiceScope scope)
    {
        return new TourProblemController(scope.ServiceProvider.GetRequiredService<ITourProblemService>())
        {
            ControllerContext = BuildContext("-1")
        };
    }
}
