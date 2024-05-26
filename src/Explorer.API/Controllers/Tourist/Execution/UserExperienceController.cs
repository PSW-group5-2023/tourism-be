using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist.Execution
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/userExperience")]
    public class UserExperienceController : BaseApiController
    {
        private readonly IUserExperienceService _userExperienceService;

        public UserExperienceController(IUserExperienceService userExperienceService)
        {
            _userExperienceService = userExperienceService;
        }

        [HttpGet]
        public ActionResult<PagedResult<UserExperienceDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _userExperienceService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpGet("userxp/{userId:long}")]
        public ActionResult<PagedResult<UserExperienceDto>> GetByUserId(long userId)
        {
            var result = _userExperienceService.GetByUserId(userId);
            return CreateResponse(result);
        }
    }
}
