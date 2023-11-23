using Explorer.Tours.API.Dtos.Statistics;
using Explorer.Tours.API.Public.Execution;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Author.Authoring
{
    [Authorize(Policy = "authorPolicy")]
    [Route("api/author/session")]
    public class SessionController : BaseApiController
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }


        [HttpGet("getAttendedStats")]
        public ActionResult<List<TourStatisticsDto>> GetAttendanceStatistics()
        {
            var result = _sessionService.GetAttendanceStatistics();
            return CreateResponse(result);
        }

        [HttpGet("getAbandonedStats")]
        public ActionResult<List<TourStatisticsDto>> GetAbandonedStatistics()
        {
            var result = _sessionService.GetAbandonedStatistics();
            return CreateResponse(result);
        }
    }
}
