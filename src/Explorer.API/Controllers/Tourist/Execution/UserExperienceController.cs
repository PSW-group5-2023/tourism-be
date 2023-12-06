using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Core.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist.Execution
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/userExperience")]
    public class UserExperienceController:BaseApiController
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
        [HttpPost]
        public ActionResult<UserExperienceDto> Create([FromBody] UserExperienceDto userExperience)
        {
            var result = _userExperienceService.Create(userExperience);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<UserExperienceDto> Update([FromBody] UserExperienceDto userExperience)
        {
            var result = _userExperienceService.Update(userExperience);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _userExperienceService.Delete(id);
            return CreateResponse(result);
        }
    }
}
