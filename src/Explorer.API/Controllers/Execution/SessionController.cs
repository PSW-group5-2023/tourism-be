using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Execution;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Execution
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/session")]
    public class SessionController : BaseApiController
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpPost]
        public ActionResult<SessionDto> Create([FromBody] SessionDto session)
        {
            var result = _sessionService.Create(session);
            return CreateResponse(result);
        }

        [HttpPut]
        public ActionResult<SessionDto> Update([FromBody] SessionDto session)
        {
            var result = _sessionService.Update(session);
            return CreateResponse(result);
        }
    }
}
