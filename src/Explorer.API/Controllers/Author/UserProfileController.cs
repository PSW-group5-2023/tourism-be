using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Author
{
    [Authorize(Policy = "authorPolicy")]
    [Route("api/author/userProfile")]
    public class UserProfileController : BaseApiController
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [HttpGet("{id:int}")]
        public ActionResult GetById(int id)
        {
            var result = _userProfileService.GetById(id);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult Update([FromBody] UserProfileDto userProfile, int id)
        {
            var result = _userProfileService.Update(userProfile, id);
            return CreateResponse(result);
        }
    }
}
