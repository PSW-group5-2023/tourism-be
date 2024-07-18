using Explorer.BuildingBlocks.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Achievements.Tests
{
    public class BaseAchievementsIntegrationTest : BaseWebIntegrationTest<AchievementsTestFactory>
    {
        public BaseAchievementsIntegrationTest(AchievementsTestFactory factory) : base(factory)
        {
        }
    }
}
