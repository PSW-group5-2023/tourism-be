using Explorer.Achievements.API.Dtos;
using Explorer.Achievements.API.Public;
using Explorer.Tours.API.Dtos.Equipment;
using Explorer.Tours.API.Dtos.Execution;
using Explorer.Tours.API.Public.Equipment;
using Explorer.Tours.Core.UseCases.Equipments;
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

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _achievementService.Delete(id);
            return CreateResponse(result);
        }
    }
}
