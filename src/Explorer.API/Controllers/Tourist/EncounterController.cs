using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/encounter")]
    public class EncounterController : BaseApiController
    {
        private readonly IChallengeService _challengeService;

        public EncounterController(IChallengeService challengeController)
        {
            _challengeService = challengeController;
        }

        [HttpGet]
        public ActionResult<PagedResult<ChallengeDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _challengeService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }
    }
}
