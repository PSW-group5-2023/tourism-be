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
    }
}
