using Explorer.Achievements.API.Dtos;
using Explorer.Achievements.API.Public;
using Explorer.BuildingBlocks.Core.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/achievement")]
    public class AchievementController : BaseApiController
    {
        private readonly IAchievementService _achievementService;
        public AchievementController(IAchievementService achievementService)
        {
            _achievementService = achievementService;
        }
        [HttpGet("baseAchievemnts")]
        public ActionResult<PagedResult<AchievementDto>> GetAllBaseAchievements()
        {
            var result = _achievementService.GetAllBaseAchievements();
            return CreateResponse(result);
        }

        [HttpGet("complexAchievemnts")]
        public ActionResult<PagedResult<AchievementDto>> GetAllComplexAchievements()
        {
            var result = _achievementService.GetAllComplexAchievements();
            return CreateResponse(result);
        }
    }
}
