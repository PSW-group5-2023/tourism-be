using Explorer.Tours.API.Public.Tour;
using Microsoft.Extensions.DependencyInjection;

namespace Explorer.Tours.Tests.Integration.TourAuthoring.Tourist
{
    [Collection("Sequential")]
    public class TouristTourKeyPointQueryTest : BaseToursIntegrationTest
    {
        public TouristTourKeyPointQueryTest(ToursTestFactory factory) : base(factory)
        {
        }
        private static Explorer.API.Controllers.Tourist.CheckpointController CreateController(IServiceScope scope)
        {
            return new Explorer.API.Controllers.Tourist.CheckpointController(scope.ServiceProvider.GetRequiredService<ICheckpointService>(), scope.ServiceProvider.GetRequiredService<IPublicCheckpointService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }

        /* [Fact]
         public void RetrievesAllByPublicId()
         {
             //Arrange
             using var scope = Factory.Services.CreateScope();
             var controller = CreateController(scope);

             //Act
             var result = ((ObjectResult)controller.GetAllByPublicKeypointId(-5).Result);

             //Assert
             result.ShouldNotBe(null);
             result.StatusCode.ShouldBe(200);
         }*/

    }
}
