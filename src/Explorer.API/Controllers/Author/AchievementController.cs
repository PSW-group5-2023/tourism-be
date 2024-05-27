using Explorer.Achievements.API.Dtos;
using Explorer.Achievements.API.Public;
using Explorer.BuildingBlocks.Core.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Explorer.API.Controllers.Author
{
    [Authorize(Policy = "authorPolicy")]
    [Route("api/author/achievement")]
    public class AchievementController : BaseApiController
    {
        private readonly IAchievementService _achievementService;

        public AchievementController(IAchievementService achievementService)
        {
            _achievementService = achievementService;
        }

        [HttpPost]
        public ActionResult<AchievementDto> Create([FromBody] AchievementDto achievement)
        {
            var result = _achievementService.Create(achievement);
            return CreateResponse(result);
        }

        [HttpGet("{id:int}")]
        public ActionResult<AchievementDto> Get(int id)
        {
            var result = _achievementService.Get(id);
            return CreateResponse(result);
        }

        [HttpGet]
        public ActionResult<PagedResult<AchievementDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _achievementService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _achievementService.Delete(id);
            return CreateResponse(result);
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
    }
}
