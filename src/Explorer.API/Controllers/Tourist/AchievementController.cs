using Explorer.Achievements.API.Dtos;
using Explorer.Achievements.API.Dtos.Tourist;
using Explorer.Achievements.API.Public;
using Explorer.BuildingBlocks.Core.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "guestOrTouristPolicy")]
    [Route("api/tourist/achievement")]
    public class AchievementController : BaseApiController
    {
        private readonly IAchievementService _achievementService;
        public AchievementController(IAchievementService achievementService)
        {
            _achievementService = achievementService;
        }

        [HttpGet("baseAchievemnts")]
        public ActionResult<List<AchievementDto>> GetAllBaseAchievements()
        {
            var result = _achievementService.GetAllBaseAchievements();
            return CreateResponse(result);
        }

        [HttpGet("complexAchievemnts")]
        public ActionResult<List<AchievementDto>> GetAllComplexAchievements()
        {
            var result = _achievementService.GetAllComplexAchievements();
            return CreateResponse(result);
        }

        [HttpGet("complexAchievementsWithFullRecipes/mobile")]
        public ActionResult<List<AchievementWithFullRecipeMobileDto>> GetAllComplexAchievementsWithFullRecipes()
        {
            var result = _achievementService.GetAllComplexAchievementsWithFullRecipes();
            return CreateResponse(result);
        }

        [HttpGet("complexAchievementWithFullRecipe/mobile/{id:int}")]
        public ActionResult<List<AchievementWithFullRecipeMobileDto>> GetComplexAchievementWithFullRecipe(int id)
        {
            var result = _achievementService.GetComplexAchievementWithFullRecipe(id);
            return CreateResponse(result);
        }

        [HttpGet("{id:int}")]
        public ActionResult<AchievementModuleAchievementMobileDto> Get(int id)
        {
            var result = _achievementService.GetMobile(id);
            return CreateResponse(result);
        }
    }
}
