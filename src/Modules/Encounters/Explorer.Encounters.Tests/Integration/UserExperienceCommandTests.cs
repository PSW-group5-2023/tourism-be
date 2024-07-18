using Explorer.API.Controllers.Tourist.Execution;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Explorer.Encounters.Tests.Integration
{
    [Collection("Sequential")]

    public class UserExperienceCommandTests : BaseEncountersIntegrationTest
    {
        public UserExperienceCommandTests(EncountersTestFactory factory) : base(factory)
        {
        }

        private static UserExperienceController CreateController(IServiceScope scope)
        {
            return new UserExperienceController(scope.ServiceProvider.GetRequiredService<IUserExperienceService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
