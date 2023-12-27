using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Tours.API.Dtos.TouristTour;
using Explorer.Tours.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    //[Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/userNews")]
    public class UserNewsController : BaseApiController
    {
        private readonly IUserNewsService _userNewsService;

        public UserNewsController(IUserNewsService userNewsService)
        {
            _userNewsService = userNewsService;
        }

        [HttpGet("{id:int}")]
        public ActionResult<UserNewsDto> Get(int id)
        {
            var result = _userNewsService.Get(id);
            return CreateResponse(result);
        }
        [HttpPut("")]
        public ActionResult<UserNewsDto> Update([FromBody] UserNewsDto news)
        {
            var result = _userNewsService.Update(news);
            return CreateResponse(result);
        }

    }
}
