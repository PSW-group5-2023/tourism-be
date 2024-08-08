using Explorer.BuildingBlocks.Tests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Achievements.Tests
{
    public class BaseAchievementsIntegrationTest : BaseWebIntegrationTest<AchievementsTestFactory>
    {
        public BaseAchievementsIntegrationTest(AchievementsTestFactory factory) : base(factory)
        {

        }
        protected static ControllerContext BuildAchievementContext(string id)
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
