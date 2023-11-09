using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist.Identity
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/follower")]
    public class FollowerController : BaseApiController
    {
        private readonly IFollowerService _followerService;

        public FollowerController(IFollowerService followerService)
        {
            _followerService = followerService;
        }

        [HttpGet("{id:int}")]
        public ActionResult<FollowerDto> Get(int id)
        {
            var result = _followerService.Get(id);
            return CreateResponse(result);
        }

        [HttpPut]
        public ActionResult<FollowerDto> Create([FromBody] FollowerDto follower)
        {
            var result = _followerService.Create(follower);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _followerService.Delete(id);
            return CreateResponse(result);
        }
    }
}
