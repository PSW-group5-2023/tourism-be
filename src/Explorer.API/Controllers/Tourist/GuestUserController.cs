using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{

    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/guestUser")]
    public class GuestUserController : BaseApiController
    {

        private readonly IGuestUserService _guestUserService;

        public GuestUserController(IGuestUserService guestUserService)
        {
            _guestUserService = guestUserService;
        }

        [HttpGet]
        public ActionResult<PagedResult<GuestUserDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _guestUserService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _guestUserService.Delete(id);
            return CreateResponse(result);
        }
    }
}
