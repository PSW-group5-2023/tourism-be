using Explorer.BuildingBlocks.Tests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Explorer.Encounters.Tests
{
    public class BaseEncountersIntegrationTest : BaseWebIntegrationTest<EncountersTestFactory>
    {
        public BaseEncountersIntegrationTest(EncountersTestFactory factory) : base(factory)
        {
        }

        protected static ControllerContext BuildEncounterContext(string id)
    {
        return new ControllerContext()
        {
            HttpContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal(new ClaimsIdentity(new[]
                {
                    new Claim("id", id)
                }))
            }
        };
    }
    }
}
