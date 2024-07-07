using Explorer.API.Controllers.Tourist;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Dtos.Problem;
using Explorer.Tours.API.Public.Problem;
using Explorer.Tours.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Shouldly;


namespace Explorer.Tours.Tests.Integration.Administration.TourProblem;

[Collection("Sequential")]
public class TourProblemCommandTests : BaseToursIntegrationTest
{
    public TourProblemCommandTests(ToursTestFactory factory) : base(factory) { }

    [Fact]
    public void Creates()
    {
        // Arrange
        using var scope = Factory.Services.CreateScope();
        var controller = CreateTouristController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();
        var newEntity = new TourProblemDto
        {
            Id = -5,
            TouristId = -6,
            TourId = -3,
            Category = TourProblemCategory.GUIDE_SERVICES,
            Priority = TourProblemPriority.LOW,
            Description = "Vodic je zakasnio",
            Time = DateTime.Now.ToUniversalTime(),
            TouristUsername = "tourist",
            AuthorUsername = "author",
            IsSolved = false,
            Messages = new List<TourProblemMessageDto>(),
            Deadline = DateTime.Now.ToUniversalTime()
        };


        // Act
        var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as TourProblemDto;

        // Assert - Response
        result.ShouldNotBeNull();
        result.Id.ShouldNotBe(0);
        result.TouristId.ShouldNotBe(0);
        result.TourId.ShouldNotBe(0);
        result.Category.ShouldBe(newEntity.Category);
        result.Priority.ShouldBe(newEntity.Priority);
        result.Description.ShouldBe(newEntity.Description);
        result.Time.ShouldBe(newEntity.Time);
        // result.TouristUsername.ShouldBe(newEntity.TouristUsername);
        // result.AuthorUsername.ShouldBe(newEntity.AuthorUsername);
        result.IsSolved.ShouldBe(newEntity.IsSolved);
        result.Messages.ShouldBe(newEntity.Messages);
        result.Deadline.ShouldBe(newEntity.Deadline);

        // Assert - Database
        var storedEntity = dbContext.TourProblems.FirstOrDefault(i => i.Description == newEntity.Description);
        storedEntity.ShouldNotBeNull();
        storedEntity.Id.ShouldBe(result.Id);
        storedEntity.TouristId.ShouldBe(result.TouristId);
        storedEntity.TourId.ShouldBe(result.TourId);
        ((int)storedEntity.Category).ShouldBe((int)result.Category);
        ((int)storedEntity.Priority).ShouldBe((int)result.Priority);
        storedEntity.Time.ShouldBe(result.Time);
        storedEntity.IsSolved.ShouldBe(result.IsSolved);
        storedEntity.Deadline.ShouldBe(result.Deadline);
    }

    [Fact]
    public void Create_fails_invalid_data()
    {
        //Arrange
        using var scope = Factory.Services.CreateScope();
        var controller = CreateTouristController(scope);
        var newEntity = new TourProblemDto()
        {
            Category = TourProblemCategory.BOOKING,
            Priority = TourProblemPriority.MEDIUM
        };

        // Act
        var result = (ObjectResult)controller.Create(newEntity).Result;

        // Assert
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(400);
    }
    [Fact]
    public void Updates()
    {
        // Arrange
        using var scope = Factory.Services.CreateScope();
        var controller = CreateTouristController(scope);
        var dbContext = scope.ServiceProvider.GetRequiredService<ToursContext>();
        var updatedEntity = new TourProblemDto
        {
            Id = -1,
            TouristId = -8,
            TourId = -3,
            Category = TourProblemCategory.BOOKING,
            Priority = TourProblemPriority.MEDIUM,
            Description = "Rez",
            Time = DateTime.Now.ToUniversalTime(),
            TouristUsername = null,
            AuthorUsername = null,
            IsSolved = false,
            Messages = new List<TourProblemMessageDto>(),
            Deadline = DateTime.Now.ToUniversalTime()
        };

        // Act
        var result = ((ObjectResult)controller.Update(updatedEntity).Result)?.Value as TourProblemDto;

        // Assert - Response
        result.ShouldNotBeNull();
        result.Id.ShouldNotBe(0);
        result.TouristId.ShouldNotBe(0);
        result.TourId.ShouldNotBe(0);
        result.Category.ShouldBe(updatedEntity.Category);
        result.Priority.ShouldBe(updatedEntity.Priority);
        result.Description.ShouldBe(updatedEntity.Description);
        result.Time.ShouldBe(updatedEntity.Time);
        result.TouristUsername.ShouldBe(updatedEntity.TouristUsername);
        result.AuthorUsername.ShouldBe(updatedEntity.AuthorUsername);
        result.IsSolved.ShouldBe(updatedEntity.IsSolved);
        result.Messages.ShouldBe(updatedEntity.Messages);
        result.Deadline.ShouldBe(updatedEntity.Deadline);

        // Assert - Database
        var storedEntity = dbContext.TourProblems.FirstOrDefault(i => i.Description == "Rez");
        storedEntity.ShouldNotBeNull();
        storedEntity.IsSolved.ShouldBe(updatedEntity.IsSolved);
        var oldEntity = dbContext.TourProblems.FirstOrDefault(i => i.Description == "Rezervacija nije sacuvana");
        oldEntity.ShouldBeNull();
    }

    [Fact]
    public void Update_fails_invalid_id()
    {
        // Arrange
        using var scope = Factory.Services.CreateScope();
        var controller = CreateTouristController(scope);
        var updatedEntity = new TourProblemDto
        {
            Id = -2999,
            TouristId = -6,
            TourId = -3,
            Category = TourProblemCategory.GUIDE_SERVICES,
            Priority = TourProblemPriority.LOW,
            Description = "Vodic je zakasnio",
            Time = DateTime.Now.ToUniversalTime(),
            TouristUsername = "tourist",
            AuthorUsername = "author",
            IsSolved = true,
            Messages = new List<TourProblemMessageDto> { new TourProblemMessageDto {
                SenderId = 0,
                RecipientId = 0,
                CreationTime = DateTime.Now.ToUniversalTime(),
                Description = "opis",
                IsRead = false } },
            Deadline = DateTime.Now.ToUniversalTime()
        };

        // Act
        var result = (ObjectResult)controller.Update(updatedEntity).Result;

        // Assert
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(404);
    }

    [Fact]
    public void Give_deadline()
    {
        // Arrange
        using var scope = Factory.Services.CreateScope();
        var controller = CreateAdministratorController(scope);
        List<TourProblemMessageDto> messages = JsonConvert.DeserializeObject<List<TourProblemMessageDto>>(@"[
                {
                     
		            ""SenderId"": -8,
	  	            ""RecipientId"": -3,
		            ""CreationTime"": ""2023-11-11T17:03:36.2030688Z"",
		            ""Description"": ""Jos uvek nije moguce izvrsiti rezervaciju. "",
		            ""IsRead"": false
                }
            ]");

        TourProblemDto newTourProblem = new TourProblemDto()
        {
            Id = -3,
            TouristId = -6,
            TourId = -2,
            Category = TourProblemCategory.BOOKING,
            Priority = TourProblemPriority.LOW,
            Description = "Ne moze se rezervisati ova tura",
            Time = DateTime.Parse("2023-11-11T17: 03:36.2030688Z").ToUniversalTime(),
            IsSolved = false,
            Messages = messages,
            Deadline = DateTime.Parse("2024-11-20T17: 03:36.2030688Z").ToUniversalTime()
        };
        // Act
        var result = ((ObjectResult)controller.GiveDeadline(newTourProblem).Result)?.Value as TourProblemDto;

        // Assert
        result.ShouldNotBeNull();
        result.Deadline.ShouldBeGreaterThanOrEqualTo(newTourProblem.Deadline);
    }

    [Fact]
    public void Punish_author()
    {
        // Arrange
        using var scope = Factory.Services.CreateScope();
        var controller = CreateAdministratorController(scope);
        List<TourProblemMessageDto> messages = JsonConvert.DeserializeObject<List<TourProblemMessageDto>>(@"[
                {
                     
		            ""SenderId"": -8,
	  	            ""RecipientId"": -3,
		            ""CreationTime"": ""2023-11-11T17:03:36.2030688Z"",
		            ""Description"": ""Jos uvek nije moguce izvrsiti rezervaciju. "",
		            ""IsRead"": false
                }
            ]");

        TourProblemDto newTourProblem = new TourProblemDto()
        {
            Id = -3,
            TouristId = -6,
            TourId = -2,
            Category = TourProblemCategory.BOOKING,
            Priority = TourProblemPriority.LOW,
            Description = "Ne moze se rezervisati ova tura",
            Time = DateTime.Parse("2023-11-11T17: 03:36.2030688Z").ToUniversalTime(),
            IsSolved = true,
            Messages = messages,
            Deadline = DateTime.Parse("2023-11-20T17: 03:36.2030688Z").ToUniversalTime()
        };
        // Act
        var result = ((ObjectResult)controller.PunishAuthor(newTourProblem).Result)?.Value as TourProblemDto;

        // Assert
        result.ShouldNotBeNull();
        result.IsSolved.ShouldBeTrue();
    }

    private static Explorer.API.Controllers.Administrator.TourProblemController CreateAdministratorController(IServiceScope scope)
    {
        return new Explorer.API.Controllers.Administrator.TourProblemController(scope.ServiceProvider.GetRequiredService<ITourProblemService>())
        {
            ControllerContext = BuildContext("-1")
        };
    }

    private static TourProblemController CreateTouristController(IServiceScope scope)
    {
        return new TourProblemController(scope.ServiceProvider.GetRequiredService<ITourProblemService>())
        {
            ControllerContext = BuildContext("-1")
        };
    }
}
